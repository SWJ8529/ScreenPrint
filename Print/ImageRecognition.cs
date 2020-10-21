﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Print
{
    public class ImageRecognition
    {
        private static List<string> point = new List<string>();
        private static string _URL;
        private static string path = "";
        string response = string.Empty;

        private string getConfig(string path)
        {
            try
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = path + @"\图片识别插件.exe.config"; ;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                //Configuration config = ConfigurationManager.OpenExeConfiguration(path + @"\图片识别插件.exe");
                //string connstr = config.ConnectionStrings.ConnectionStrings["Time"].ConnectionString;             
                return config.AppSettings.Settings["URL"].Value;
            }
            catch (Exception ex)
            {
                return "{\"msg\":\"读取配置文件失败!\",\"code\":500,\"data\":\"\"}";
            }
        }

        public void Recognition() 
        {
            try
            {                
                Process[] ps = Process.GetProcessesByName("图片识别插件");
                foreach (Process p in ps)
                {
                    path = p.MainModule.FileName.ToString();
                }
                path= path.Substring(0,path.LastIndexOf('\\'));

                #region 读取文件坐标
                var lines = File.ReadAllLines(path+@"\Point.txt");

                string PointJson = "{\"point\":[";

                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        PointJson += line;
                    }
                }

                PointJson += "]}";
                ReadPoint rp = JsonConvert.DeserializeObject<ReadPoint>(PointJson);
                point = rp.point;
            }catch(Exception ex)
            {
                response = "{\"msg\":\"读取坐标失败!\",\"code\":500,\"data\":\"\"}";
            }
            #endregion
        }

        // 矩形起点
        private int rectX;
        private int rectY;
        // 矩形宽高
        private int width;
        private int height;
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszoutput, IntPtr lpdate);
        [DllImport("gdi32.dll")]
        public static extern BootMode BitBlt(IntPtr hdcDest, int x, int y, int widht, int hight, IntPtr hdcsrc, int xsrc, int ysrc, System.Int32 dw);
        /// <summary>
        /// 图片识别方法
        /// </summary>
        /// <param name="Flag">是否生成图片（生成的图片将在桌面上）</param>
        /// <returns>返回解析JSON串code：500为内部程序错误 200：成功</returns>
        public string PrintImg(Boolean Flag=false)
        {
            
            Recognition();
            _URL = getConfig(path);
            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            IntPtr dc1 = CreateDC("display", null, null, (IntPtr)null);
            Graphics g1 = Graphics.FromHdc(dc1);
            Bitmap my = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, g1);
            Graphics g2 = Graphics.FromImage(my);
            IntPtr dc3 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, dc3, 0, 0, 13369376);
            g1.ReleaseHdc(dc3);
            g2.ReleaseHdc(dc2);


            #region 获取坐标
            if (point.Count > 0)
            {
                foreach (string line in point)
                {
                    rectX = Convert.ToInt32(line.Split(',')[0]);
                    rectY = Convert.ToInt32(line.Split(',')[1]);
                    width = Convert.ToInt32(line.Split(',')[2]);
                    height = Convert.ToInt32(line.Split(',')[3]);

                    // 保存图片到图片框
                    Bitmap bmp = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(my, new Rectangle(0, 0, width, height), new Rectangle(rectX, rectY, width, height), GraphicsUnit.Pixel);
                    if (Flag)
                    {
                        bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToFileTime().ToString() + ".png");
                    }
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, ImageFormat.Png);
                    byte[] picdata = ms.GetBuffer();//StreamToBytes(ms);
                    //byte[] test = new byte[10];
                    //BytesToImage(picdata);
                    response = CreatePostData(_URL, DateTime.Now.ToFileTime().ToString(), picdata);
                    ms.Close();
                    
                }
            }
            else
            {
                response="{\"msg\":\"没有坐标请使用工具设置坐标!\",\"code\":500,\"data\":\"\"}";
            }
            return response;
            #endregion
        }

        public string CreatePostData(string url, string filename, byte[] data)
        {

            Stream fileStream = new MemoryStream(data);

            BinaryReader br = new BinaryReader(fileStream);

            byte[] buffer = br.ReadBytes(Convert.ToInt32(fileStream.Length));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            //请求
            WebRequest req = WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "multipart/form-data; boundary=" + boundary;
            //组织表单数据
            StringBuilder sb = new StringBuilder();
            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"file\"; filename=\"" + filename + "\";");
            sb.Append("\r\n");
            sb.Append("Content-Type: image/png");
            sb.Append("\r\n\r\n");
            string head = sb.ToString();
            byte[] form_data = Encoding.UTF8.GetBytes(head);
            //结尾
            byte[] foot_data = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            //post总长度
            long length = form_data.Length + fileStream.Length + foot_data.Length;
            req.ContentLength = length;
            Stream requestStream = req.GetRequestStream();
            //这里要注意一下发送顺序，先发送form_data > buffer > foot_data
            //发送表单参数
            requestStream.Write(form_data, 0, form_data.Length);
            //发送文件内容
            requestStream.Write(buffer, 0, buffer.Length);
            //结尾
            requestStream.Write(foot_data, 0, foot_data.Length);
            requestStream.Close();
            fileStream.Close();
            fileStream.Dispose();
            br.Close();
           // br.Dispose();
            //响应
            WebResponse pos = req.GetResponse();
            StreamReader sr = new StreamReader(pos.GetResponseStream(), Encoding.UTF8);
            string html = sr.ReadToEnd().Trim();
            sr.Close();
            sr.Dispose();
            if (pos != null)
            {
                pos.Close();
                pos = null;
            }
            if (req != null)
            {
                req = null;
            }
            return html;
        }
    }

    public class ReadPoint
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> point { get; set; }
    }
}
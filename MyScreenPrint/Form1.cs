﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Drawing.Imaging;
using System.Net.Http;
using RestSharp;
using System.Net.Http.Headers;

namespace MyScreenPrint
{
    public partial class Form1 : Form
    {
        // 截图窗口
        Cutter cutter = null;

        // 截得的图片
        public static Bitmap catchBmp = null;

        // 绘图参数
        enum Tools { Pen, Text};
        Graphics catchBmpGraphics = null;  // 图形设备
        Color color = Color.White;  // 选择的颜色

        public Form1()
        {
            InitializeComponent();

            // 双缓冲
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                           ControlStyles.AllPaintingInWmPaint,
                           true);
            this.UpdateStyles();
        }

        #region 按钮事件
      
        // 点击按钮开始捕捉屏幕
        private void printScrBtn_Click(object sender, EventArgs e)
        {

            // 新建一个截图窗口
            cutter = new Cutter();

            // 隐藏原窗口
            Hide();
            Thread.Sleep(200);

            // 设置截图窗口的背景图片
            Bitmap bmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(bmp.Width, bmp.Height));
            cutter.BackgroundImage = bmp;

            // 显示原窗口
            Show();

            // 显示截图窗口
            cutter.WindowState = FormWindowState.Maximized;
            cutter.ShowDialog();

            textBox1.Text = cutter.sb.ToString();
            label1.Text = "设置坐标个数：" + Program.point.Count;
            // 显示所截得的图片
            //UpdateScreen();

            // 获取截图图片的图形设备
            //catchBmpGraphics = Graphics.FromImage(catchBmp);
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            SaveImg();
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
        public void SaveImg()
        {
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
            if (Program.point.Count > 0)
            {
                foreach (string line in Program.point)
                {
                    rectX = Convert.ToInt32(line.Split(',')[0]);
                    rectY = Convert.ToInt32(line.Split(',')[1]);
                    width = Convert.ToInt32(line.Split(',')[2]);
                    height = Convert.ToInt32(line.Split(',')[3]);

                    // 保存图片到图片框
                    Bitmap bmp = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(my, new Rectangle(0, 0, width, height), new Rectangle(rectX, rectY, width, height), GraphicsUnit.Pixel);

                    bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\"+DateTime.Now.ToFileTime().ToString()+".jpg");
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, ImageFormat.Png);

                    //using (var client = new HttpClient())
                    //using (var content = new MultipartFormDataContent())
                    //{
                    //    client.BaseAddress = new Uri("http://118.25.1.155:9527/ocr");
                    //    var fileContent1 = new ByteArrayContent(File.ReadAllBytes(@"D:/8cb857379572edf39ea92e5d574acb9.png"));
                    //    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    //    {
                    //        Name = "\"file\"",
                    //        FileName = "\"8cb857379572edf39ea92e5d574acb9.png\""
                    //    };
                    //    fileContent1.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    //    //content.Headers.Add("Content-Tpye","image/png");
                    //    content.Add(fileContent1);
                    //    //content.Add(dataContent);
                    //    var result = client.PostAsync("", content).Result;
                    //    string str = result.Content.ReadAsStringAsync().Result;
                    //}
                }
            }
            else {
                MessageBox.Show("请设置坐标！","提示");
            }

            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "设置坐标个数：" + Program.point.Count;
            if (Program.point.Count > 0)
            {
                foreach (string line in Program.point)
                {
                    textBox1.Text += line+"\r\n";
                }
            }
        }

        private void Clean_Point_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(Environment.CurrentDirectory + @"/Point.txt", FileMode.Open, FileAccess.Write);
            System.IO.File.SetAttributes(Environment.CurrentDirectory + @"/Point.txt", FileAttributes.Hidden);
            StreamWriter sr = new StreamWriter(fs);
            fs.Seek(0, SeekOrigin.Begin);
            fs.SetLength(0);
            sr.Close();
            fs.Close();
            Program.point.Clear();
            textBox1.Text = "";
            label1.Text= "设置坐标个数：" + Program.point.Count;
            MessageBox.Show("已清空！");
        }

        public static byte[] AuthGetFileData(string fileUrl)
        {
            FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
            byte[] buffur = new byte[fs.Length];

            fs.Read(buffur, 0, buffur.Length);
            fs.Close();
            return buffur;
        }
        private void sendFile_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                client.BaseAddress = new Uri("http://118.25.1.155:9527/ocr");
                var filecontent1 = new ByteArrayContent(File.ReadAllBytes(@"d:/8cb857379572edf39ea92e5d574acb9.png"));
                filecontent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"file\"",
                    FileName = "\"8cb857379572edf39ea92e5d574acb9.png\""
                };
                filecontent1.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                //content.headers.add("content-tpye","image/png");
                content.Add(filecontent1);
                //content.add(datacontent);
                var result = client.PostAsync("", content).Result;
                textBox2.Text = result.Content.ReadAsStringAsync().Result;
            }
        }


    }
}
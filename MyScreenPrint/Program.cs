using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace MyScreenPrint
{
    static class Program
    {
        public static List<string> point = new List<string>();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            #region 读取文件坐标
            var lines = File.ReadAllLines(Environment.CurrentDirectory + @"/Point.txt");
            
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
            #endregion
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
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

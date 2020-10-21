using MyScreenPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Print
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageRecognition image = new ImageRecognition();
            Form1 f = new Form1();
            ReadZB zb = new ReadZB();
            zb.readpoint();//读取坐标
            Console.WriteLine(f.SaveImg(false)); 
            Console.ReadKey();
        }
    }
}

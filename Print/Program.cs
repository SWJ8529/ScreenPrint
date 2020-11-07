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
            Console.WriteLine(image.PrintImg()); 
            Console.ReadKey();
        }
    }
}

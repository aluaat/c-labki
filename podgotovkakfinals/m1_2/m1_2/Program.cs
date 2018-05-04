using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace m1_2
{
    class Program
    {
        public  static void ex1()
        {
 FileInfo f = new FileInfo(@"C:\Users\user\c#labki");
           
            Console.WriteLine(f.Name);
            Console.WriteLine(f.FullName);
            Console.Write(f.Directory);
            Console.ReadKey();
        }
        public static void ex2()
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\user\c#labki");
            Console.WriteLine(d.Name);
            Console.WriteLine(d.FullName);
        
            Console.ReadKey();

        }

        static void Main(string[] args)
        {
            ex2();  
        }
    }
}

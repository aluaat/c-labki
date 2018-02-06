using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace minmax
{
    class Program
    {
        static void Main(string[] args)
        {
            string line0 = System.IO.File.ReadAllText(@"C:\Users\user\c#labki\textfile.txt"); //1 2 3 4 5 6 -5 -8 0 input txt
            string[] array = line0.Split(' '); //sozdaem massiv ,razdelyaem po probelam
            int mx = -999999999;
            int mn = 999999999;

            foreach (string el in array) //foreach loop
            {
                mx = Math.Max(mx, int.Parse(el)); // 1 2 3 4 5 6 6 6 {6}
                mn = Math.Min(mn, int.Parse(el)); //1 1 1 1 1 1 -5 -8 {-8}
            }
            Console.WriteLine("макс число: ");
            Console.WriteLine(mx);
            Console.WriteLine("мин число: ");
            Console.WriteLine(mn);
            Console.ReadKey();

        }
    }
}

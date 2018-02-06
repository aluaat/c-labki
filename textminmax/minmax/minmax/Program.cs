using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                mx = Math.Max(mx, int.Parse(el)); // 1 2 3 4 5 6 6 6 6
                mn = Math.Min(mn, int.Parse(el)); //1 1 1 1 1 1 -5 -8 -8
            }
            Console.WriteLine("макс число: ");
            Console.WriteLine(mx);
            Console.WriteLine("мин число: ");
            Console.WriteLine(mn);
            Console.ReadKey();


            /*string ot = "";
            string text = System.IO.File.ReadAllText(@"C:\Users\user\c#labki\textfile.txt");

            string[] arr = text.Split(' ');
            int min = int.Parse(arr[0]);
            int max = int.Parse(arr[0]);
            int sum = 0;
            string mn = "", mx = "";
            for (int i = 0; i <= (arr.Length) - 1; i++)
            {
                sum = int.Parse(arr[i]);
                if (sum <= min)
                {
                    min = sum;
                    mn = arr[i];
                }
                if (sum >= max)
                {
                    max = sum;
                    mx = arr[i];
                }

            }
            ot = mn + " " + mx;
            System.IO.File.WriteAllText(@"C:\Users\user\c#labki\textfile.txt", ot);*/
        }
    }
}

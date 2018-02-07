using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace primemin
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C: \Users\user\c#labki\textfile.txt");
            string line = sr.ReadLine();
            String[] massiv = line.Split(' ');
            bool Prime = true;
            int min = 999999999;
            string minn;
            foreach (string elem in massiv)
            {
                if (int.Parse(elem) <= 1) //chtob minusov ne schital i do edinichki
                {
                    Prime = false;
                    continue;

                }
                
                

                for (int j = 2; j < int.Parse(elem); j++)
                {
                    if (int.Parse(elem) % j == 0)
                    {
                        Prime = false;
                        

                    }
                }
                if (Prime == true) //0 1 1 2 3 4 5 6 6 7 7 
                {
                  /* if(min> int.Parse(elem))
                    {
                        min = int.Parse(elem);
                    }*/
                    min = Math.Min(min, int.Parse(elem)); //2
                    
                }
                Prime = true;
            }
            if (min != 999999999)
            {
                minn = min.ToString();
            }
            else
            {
                minn = "we dont have primes";
            }
            Console.WriteLine("minprime:");
            Console.WriteLine(minn);
            Console.ReadKey();

        }
    }
}

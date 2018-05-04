using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //n=4,2^4=16
            string s=Console.ReadLine();
            int  n = int.Parse(s);
            int result = 1;
            int pow = 0;
           /* for (int i=0;i<n;i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
            Console.ReadKey();*/
            
           /*double  result =Math.Pow(2, n);
            Console.WriteLine(result);
            Console.ReadKey();*/
            
            for (int i=0;i<n;i++)
            {
                pow += 1;   
                result *= pow;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}

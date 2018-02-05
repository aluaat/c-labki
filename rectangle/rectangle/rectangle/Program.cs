using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectangle
{


    class rectangle
    {
        public int width;
        public int length;
        public int P;
        public int A;
        
        public rectangle()
        {
            this.width = int.Parse(Console.ReadLine());
            this.length = int.Parse(Console.ReadLine());
            Perim();
            Area();
        }
        public int Perim()
        {
            P = width + length;
            return P;
           
        }

        public int Area()
        {
            A = width * length;
            return A;
        }
        public override string ToString()
        {
            return "P:" + P + ";  " + "A:" + A;
        }
    }
    class Program
    {
        

        static void Main(string[] args)
        {
            rectangle a = new rectangle();

            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}

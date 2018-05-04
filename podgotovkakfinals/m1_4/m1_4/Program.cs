using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace m1_4
{
    class Program
    {
        public static int k;
        public static void Draw1()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("********");
            }
           Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("********");
            }
            Console.ForegroundColor = ConsoleColor.Black;
           Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("********");
            }
        }
        public static void Draw2()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("********");
            }
           Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("********");
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("********");
            }
        }
        public static void Draw3()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("********");
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("********");
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("********");
            }
        }
        public static void trafficjam()
        {
            while (true)
            {
                Console.Clear();
                switch (k)
                {
                    case 1:
                        Draw1();
                        break;
                    case 2:
                        Draw2();
                        break;
                    case 3:
                        Draw3();
                        break;
                }
                Thread.Sleep(1000);
            }

        }
        static void Main(string[] args)
        {

           Thread thread = new Thread(trafficjam);
            thread.Start();
            int x = 0;
            while (true)
            {
                if (x % 3 == 0)
                {
                    k = 1;
                }
                if (x % 3 == 1)
                {
                    k = 2;
                }
                if (x % 3 == 2)
                {
                    k = 3;
                }
                x++;
                Thread.Sleep(1000);
            }
        }
    }
}

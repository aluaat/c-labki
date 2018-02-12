using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complexnumber
{
    class complex
    {
        public int a, b;
        public complex() { }
        public complex(int x,int y)
        {


            a = x;
            b = y;
       

            //this.a = int.Parse(Console.ReadLine()); //числитель 
            // this.b = int.Parse(Console.ReadLine()); //знаменатель

        }
        /*public  complex add(complex com3) //this->com.com3->com2
          {
              complex res = new complex(this.a + com3.a, this.b + com3.b);
              res.simplify();
              return res;
          }*/
       

        public static complex operator +(complex c1,complex c2) // 2/5 6/8  
        {
            complex p = new complex(c1.a*c2.b+ c2.a*c1.b,c2.b*c1.b);
            p.simplify(); 
            return p;
            
        }
        public static complex operator -(complex c1, complex c2)
        {
            complex m = new complex(c1.a * c2.b - c2.a * c1.b, c1.b * c2.b);
            m.simplify();
            return m;
        }

        public static complex operator *(complex c1, complex c2)
        {
            complex um = new complex(c1.a * c2.a, c1.b * c2.b);
            um.simplify();
            return um;
        }
        public static complex operator /(complex c1, complex c2)
        {
            complex d = new complex(c1.a * c2.b, c1.b * c2.a);
            d.simplify();
            return d;
        }
        public void simplify()
        {
            int c = this.a;
            int d = this.b;
            while(c>0 && d>0)
            {
                if(c>d)
                {
                    c = c % d;
                }
                else
                {
                    d = d % c;
                }
  
            }
            int gcd = c + d;
            this.a /= gcd;
            this.b /= gcd;



        }
        public override string ToString()
        {
            return a + "/" + b;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            /* complex com = new complex(5, 6);
             complex com2 = new complex(1, 2);
             //  complex com3 = com.add(com2);
             complex com3 = com + com2;
             //complex com3 = com.add(com2);
           // com3.simplify();
             Console.WriteLine(com3);*/
            string a = Console.ReadLine(); //2/5 6/8
            string[] massiv = a.Split(' ');
            string[] arr1 = massiv[0].Split('/'); //2 5
            string[] arr2 = massiv[1].Split('/'); //6 8
            complex com = new complex(int.Parse(arr1[0]), int.Parse(arr1[1]));
            complex com2 = new complex(int.Parse(arr2[0]), int.Parse(arr2[1]));
            complex p = com + com2;
            complex m = com - com2;
            complex um = com * com2;
            complex del = com / com2;

            Console.WriteLine("sum:");
            Console.WriteLine(p);
            Console.WriteLine("subtraction:");
            Console.WriteLine(m);
            Console.WriteLine("product:");
            Console.WriteLine(um);
            Console.WriteLine("division:");
            Console.WriteLine(del);



            Console.ReadKey();
        }
    }
}

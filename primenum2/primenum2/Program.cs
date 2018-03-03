using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primenum2
{
    class Complex
    {
        public int a, b;
        public Complex() { }
        public Complex(int x, int y)
        {
            this.a = x;
            this.b = y;
        }

        // this->cmp1, c -> cmp2
       

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex res = new Complex(c1.a + c2.a, c1.b + c2.b);
            res.Simplify();
            return res;
        }

       

        public void Simplify()
        {
            int _a = this.a;
            int _b = this.b;

            while (_a > 0 && _b > 0)
            {
                if (_a > _b)
                    _a = _a % _b;
                else
                    _b = _b % _a;
            }
            // _a = 0, _b = 0 gcd(a, b) = _a + _b
            int gcd = _a + _b;
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
             complex com = new complex(5, 6);
            complex com2 = new complex(1, 2);
            complex com3 = com + com2;
            //complex com3 = com.add(com2);
            com3.simplify();
            Console.WriteLine(com3);
            
            Console.ReadKey();

          
        }
    }
}

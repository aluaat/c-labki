using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace comp
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
        public Complex Add(Complex c)
        {
            Complex res = new Complex(this.a + c.a, this.b + c.b);
            // res = new Complex(6, 8);
            // res.a = 6
            // res.b = 8
            return res;

        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex res = new Complex(c1.a + c2.a, c1.b + c2.b);
            res.Simplify();
            return res;
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex res = new Complex(c1.a - c2.a, c1.b - c2.b);
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
            /*
           // "5/6 1/2"
           string s = Console.ReadLine();
           string[] token = s.Split();
           // token[0] = "5/6"
           // token[1] = "1/2"
           string[] arr1 = token[0].Split('/'); // arr1[0] = '5' arr1[1] = '6'
           string[] arr2 = token[1].Split('/'); // arr2[0] = '1' arr2[1] = '2'
           Complex cmp1 = new Complex(int.Parse(arr1[0]), int.Parse(arr1[1]));
           Complex cmp2 = new Complex(int.Parse(arr2[0]), int.Parse(arr2[1]));
           // Complex cmp3 = cmp1.Add(cmp2); // (6, 8)
           Complex cmp3 = cmp1 + cmp2;
           // Complex cmp4 = cmp1 - cmp2;

           Console.WriteLine(cmp3);

           */
            // "1/2 4/5 5/7 3/8"
            string s = Console.ReadLine();
            string[] token = s.Split();
            Complex result = new Complex(0, 0);
            // for (int i = 0; i < token.Count(); i++)
            // t = token[i]
            foreach (string t in token)
            {
                string[] arr = t.Split('/');
                Complex cmp = new Complex(int.Parse(arr[0]), int.Parse(arr[1]));
                result = result + cmp;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}

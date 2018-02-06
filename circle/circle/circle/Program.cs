using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circle
{
    class circle
    {
        public double radius;
        public double area, circumference, diametre;

        public double circ()
        {
            return this.radius = double.Parse(Console.ReadLine()); //kogda double vvodim s zapyatoi

        }
        public double are ()
        {
            return area = Math.PI * radius * radius;

        }
        public void circumferenc()
        {
            circumference = Math.PI * 2 * radius;

        }

        public void diametr()
        {
            diametre = 2 * radius;
        }

        public override string ToString()
        {
            return "Area:" + area + "\ncircumference:" + circumference + "\ndiametre:" + diametre;
        }



    }


    class Program
    {
        static void Main(string[] args)
        {
            circle c = new circle();
            c.circ();
            c.are();
            c.circumferenc();
            c.diametr();
            Console.WriteLine(c);
            Console.ReadKey();

        }
    }
}

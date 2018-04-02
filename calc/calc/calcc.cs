using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class calcc
    {
        public enum Operstions
        {
            NONE,
            NUMBER,
            PLUS,
            MINUS,
            DIV,
            MUL,
            PERS,
            SQRT,
            SQR,
            COMP,
            EQUAL
        };

        public Operstions operation;
        public double firstnumber, secondnumber,memorynumber;

        public calcc()
        {
            operation = Operstions.NONE;
            firstnumber = 0;
            secondnumber = 0;
            memorynumber = 0;
        }

        public void savefirstnumber(string s)
        {
            firstnumber += double.Parse(s);
        }

        public void savesecondnumber(string s)
        {
            secondnumber += double.Parse(s);
        }

        public double plus ()
        {
            
            return  firstnumber + secondnumber;
        }
        public double minus()
        {

            return firstnumber -secondnumber;
        }
        public double mul()
        {

            return firstnumber * secondnumber;
        }
        public double div()
        {

            return firstnumber / secondnumber;
        }

        public double sqrt()
        {

            return  Math.Sqrt( firstnumber) ;
        }
        public double sqr()
        {

            return firstnumber *firstnumber;
        }

        public double com()
        {

            return 1/firstnumber;
        }
        



    }
}

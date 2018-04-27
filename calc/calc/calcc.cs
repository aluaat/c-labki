using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class calcc
    {
        public enum Operstions //mi mojem obrachhatsya k ego znachenii,sozdaet dlya nix nazvanie 
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
            COMP, // 1/x
            EQUAL //=
        };

        public Operstions operation; //ot nego sozdaem ob'ekt ,enum kak klass ,mi znaem chto on est',no ne znaem chto tam
        //i cherez operations mi mojem obrachhatsya k operation.enum ,numb ....
        public double firstnumber, secondnumber,memorynumber;

        public calcc() //sozdaem konsturktor nashego calcc-a //imya konstruktora =vsegda nazvanie classa
        {
            //vyzyvaetsya kkogda pervi raz zaxodim 
            // i zadat' pervonachal'nie znachenie kalkulatora
            operation = Operstions.NONE;//pervi raz kogda mi zaxodim,mi niche nikakie operstions vypolnyautsya 
            firstnumber = 0;
            secondnumber = 0;
            memorynumber = 0;
        }

        public void savefirstnumber(string s) //sozdaem metody (-,+,davefirstn ..) //prinimaet string 
        {
            firstnumber += double.Parse(s);
        }

        public void savesecondnumber(string s) //sozdan lokal'no,a vne meteda 
        {
            secondnumber += double.Parse(s);
        }

        public double plus () //on vozvrashaet double ,on niche ne priminaet
        {
            
            return  firstnumber + secondnumber; //tut nel'zya chto -to prisovit'
        }
        public double minus()
        {

            return firstnumber -secondnumber;
        }
        public double mul()
        {

            return firstnumber * secondnumber;
        }
        public double div() //nazvanie etix mojno po raznomu'/

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

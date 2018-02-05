using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student //s votovimi znachenyami
{
    class Student
    {
        public string university;
        public string surname;
        public int course;
        public double gpa;

        public Student() { }
        public Student(string uni, string surn, int cour, double gp)
        {
            university = uni;
            surname = surn;
            course = cour;
            gpa = gp; //kogda pisala gpa=gpa resul'tat bil=0,no kogda pomenyala nazvanie nachal prinimat' znachenie
        }

       public Student(string u, string s)
        {
            university = u;
            surname = s;

           
        } 
        public override string ToString()
        {
            return university + " " + surname + " " + course + " " + gpa;
        }



    }

    class Program {
        
            static void Main(string[] args)
            {
            Console.WriteLine("STUDENTS:");
            Student a0 = new Student("a", "b");
           
            Console.WriteLine(a0);

            Student a = new Student("KBTU", "ALUA", 1, 5.2);
           
             Console.WriteLine(a);
            Console.ReadKey();
            }
             
    }

   }     
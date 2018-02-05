using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_2 
{
    class Stud
    {
        public string name;
        public int ID;
        public float gpa;
        public Stud()
        {
            this.name = Console.ReadLine();
            this.ID = int.Parse(Console.ReadLine());
            this.gpa = float.Parse(Console.ReadLine()); //4,5-vvodim s zapyatoi
            
        }
        public override string ToString()
        {
            return name+ "^_^"+ID+ "^_^" +gpa;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student of KBTU:");
            Stud a = new Stud();
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}

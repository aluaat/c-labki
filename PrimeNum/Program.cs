using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
           
            string alua = Console.ReadLine(); //2 3 4 5 6 7
            string[] massiv = alua.Split(' '); //sdelala massiv,razdelila probelom
            bool Prime = true;
            for(int i=0;i<massiv.Length;i++) //probegaemsya do konca
            {
                if (int.Parse(massiv[i]) == 1)  //prostoe chislo nachinaetsya c 2
                {
                    continue;
                }

                
                 for(int j = 2; j < int.Parse(massiv[i]);j++) 
                {
                   if( int.Parse(massiv[i])%j==0)
                    {
                        Prime = false;
                        break;
                        
                    }

                }
               if (Prime==true)
                {
                Console.WriteLine(massiv[i]);
                   
                }

                Prime = true; //obnovlyaem bool ,esli ne pomenyat' bool ostanetsya false-m dlya sleduwix 
            }
           
            Console.ReadKey(); 
          
        } 
        
    }
}

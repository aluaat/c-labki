using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lect7_snake_
{
    [Serializable]
    class Wall
    {
        public List<point> body;
        public string sign;
        ConsoleColor color;
        public void readlevel(int level)
        {
            //  StreamReader sr = new StreamReader(@"C:\Users\user\c#labki\examples\lect7(snake)\level1.txt");
            StreamReader sr = new StreamReader(@"C:\Users\user\c#labki\examples\lect7(snake)\level" + level + ".txt");
                //peredat level cherez parametr 
                //level 2->level 2.txt
                //int level
            try // elsi videt oshibka.on ne budet vipolnyat' eto i srazu perekinet v catch
            //esli bez oshibki,to catch propustit
            {
                int n = int.Parse(sr.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string s = sr.ReadLine();//probegaemsya po strochkam
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == '*') //i=stroka(y),j-stolbec(x)
                            body.Add(new point(j, i));
                    }

                }
            }
            //nelzya pokazivat' errors useram,delaem trycatch
            //e-nazvanie peremeni
            catch(Exception e) //predstavlyaet oshibki //exception-class
            {
                Console.WriteLine(e.ToString());

            }
            finally //vipolnyaetsya v lubom sluchae
            {
                sr.Close();//sr doljen bit' global'nim
            }
           

        }
        public Wall(int level)
        {
            body = new List<point>();
            color = ConsoleColor.White;
            sign = "o";
            readlevel(level);
        }
        public void Draw()
        {
            foreach (point p in body) //probejatsya po vsem
            {
                
                    Console.ForegroundColor = color;

    

                Console.SetCursorPosition(p.x, p.y);//probegatsya po koordin
                Console.Write(sign);

            }
        }
    }
}

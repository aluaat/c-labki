using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lect7_snake_
{
    [Serializable]
    class eda
    {
        public int x, y;
        public eda()
        {
            Setrandompos();
        }
        public eda(int x,int y)
        {
            x = x;
            y = y;
        }
        public void Setrandompos()
        {
            x = new Random().Next(1, Console.WindowWidth - 1); //vozvrachaet neotrisal'noe seloe chislo v ukazannom diapozone int minvalue,int maxvalue
            y = new Random().Next(2, Console.WindowHeight - 1);
        }
        public bool foodonWall(Wall w)
        {
           

            foreach (point p in w.body)
            {
                if (p.x == x && p.y == y)
                    return false;
            }
            return true;
        }
        public bool foodonsnake(snake s)
        {
            foreach (point p in s.body)
            {
                if (p.x == x && p.y == y)
                    return false;
            }
            return true;
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("$");
        }
    }
}

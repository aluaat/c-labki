using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lect7_snake_
{
    [Serializable]
    class snake
    {
        //i v etom klasse mi xotim sozdat' neskol'ko elementov (x,y) //kucha points
        public List<point> body;//massiv /vektorni massiv  //string[] massiv=

        public string sign;
        public ConsoleColor color; //color zmeiki
        public int cnt;
       

        public snake()
        {
            
            cnt = 0;//za kolichestvo
            sign = "*";
            body = new List<point>(); //i v etot body
            body.Add(new point(10, 10));//dobavlyaem golovu s koordin(10,10)
            color = ConsoleColor.Magenta;
        }
        public void AddB()
        {
            body.Add(new point(0, 0));
        }
        public void Move(int dx, int dy) //konstruktor kotori dvigaet nashu zmeiku //metodi pishem s zaglavnoi bukvoi
        {
            //dx,dy-kuda dvigaetsya
            //chas u nas est' tok golova
            //chtob podvigat'
            cnt++;//uvelichivaetsya kogda move
            if (cnt % 20 == 0)//kajdi 20 steps ,budet hvost dobavlyat'
            {
                //dopustim proshli 20 hodov,i  dobavlyaetsya point (0,0),i avtomatom priklepitsya   k golove
                body.Add(new point(0, 0));
            }
            for (int i = body.Count - 1; i > 0; i--) //polnostu hvost pomeyali,i potom napravlenie golovi
            {
                body[i].x = body[i-1].x;
                body[i].y = body[i-1 ].y; 
            }
            body[0].x += dx;  //body[0]-golova

            body[0].y += dy;
            if(body[0].x<0) //chtobi ne vishel za grab
            {
                body[0].x = Console.WindowWidth - 1;
            }
            if (body[0].x >=Console.WindowWidth)
            {
                body[0].x = 0;
            }
            if (body[0].y < 0)
            {
                body[0].y = Console.WindowHeight - 1;
            }
            if (body[0].y >= Console.WindowHeight)
            {
                body[0].y = 0;
            }
        }
        public void Draw()
        {
            
           // Console.SetCursorPosition(body[0].x, body[0].y);//golova
            Console.ForegroundColor = color;
            //  Console.Write("*"); tut risovali toko odnu zvezdochku
            //a teper' nujno vsu golovu:
            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                }
                else
                    Console.ForegroundColor = color;

                /*int index = 0;//golova

              foreach(point p in body) //probejatsya po vsem
                {
                    if (index != 0)

                        Console.ForegroundColor = color;

                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                        */

                Console.SetCursorPosition(body[i].x,body[i].y);//probegatsya po koordin
                Console.Write(sign);

            }
        }

        public bool CollisionWithWall(Wall w)
        {
            foreach (point p in w.body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            }
            return false;
        }
        public bool Collision() // Snake's collision with its own body
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }
        public bool Eat(eda f)
        {
            if (body[0].x == f.x && body[0].y == f.y)
            {
                return true;
            }
            return false;
        }
    }
}


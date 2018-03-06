using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.IO;

namespace lect7_snake_
{
    class Program
    {
        static snake Sn = new snake();//sozdaem global'nuyu peremenu
        static Wall wall = new Wall(level);
        static eda food = new eda();
        static int direction = 1; //left-1,right-2,up-3,down-4 
        static bool gameover = true;
        static int speed = 400;
        static int level = 1;
        static int points = F7();
        static int score = 0;



        static void F1(snake Sn)
        {
            FileStream fs = new FileStream("dataSN.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Sn);
            fs.Close();
        }
        static snake F2()
        {
            FileStream fs = new FileStream("dataSN.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            snake s = bf.Deserialize(fs) as snake;
            fs.Close();
            return s;
        }
        static void F3(Wall wall)
        {
            FileStream fs = new FileStream("dataW.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, wall);
            fs.Close();
        }
        static Wall F4()
        {
            FileStream fs = new FileStream("dataW.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Wall w = bf.Deserialize(fs) as Wall;
            fs.Close();
            return w;
        }
        static void F5(eda food)
        {
            FileStream fs = new FileStream("dataF.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, food);
            fs.Close();
        }
        static eda F6()
        {
            FileStream fs = new FileStream("dataF.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            eda f = bf.Deserialize(fs) as eda;
            fs.Close();
            return f;
        }

        static int F7()
        {
            StreamReader sr = new StreamReader(@"C:\Users\user\c#labki\examples\lect7(snake)\points.txt");
            string s = sr.ReadLine();
            sr.Close();
            return int.Parse(s);
        }
        static void F8(int a)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\user\c#labki\examples\lect7(snake)\points.txt");
            sw.WriteLine(a);
            sw.Close();

        }



       public static void playgame()
        {
            //v potoke main upravlyat' tol'ko knopkami 
            //v potoke kotori mi sozdadim zapustit' playgame
            while (!gameover) //dvigat' po directions
            {
                if (direction == 1)
                {
                    Sn.Move(-1, 0);
                }
                if (direction == 2)
                {
                    Sn.Move(1, 0);
                }
                if (direction == 3)
                {
                    Sn.Move(0, -1);
                }
                if (direction == 4)
                {
                    Sn.Move(0, 1);
                }
                // ThreadStaticAttribute;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("High score : " + " " + points + "   Score: " + score + " " + "Level" + " " + level);
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("If you want to save current score, enter [Probel]");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("If you want to quit, enter [Escape] ");
                if (Sn.CollisionWithWall(wall) || Sn.Collision())
                {
                    Console.Clear();
                    Console.SetCursorPosition(7, 7);
                    Console.ReadKey();

                    Console.Clear();
                    speed = 400;
                    Sn = new snake();
                    level = 1;
                    wall = new Wall(level);
                    score = 0;

                }
                while (!food.foodonWall(wall) || !food.foodonsnake(Sn))
                {
                    food.Setrandompos();
                    Console.SetCursorPosition(food.x, food.y);
                    Console.Write("$");
                }
                if (Sn.Eat(food))
                {
                    Sn.AddB();
                    food.Setrandompos();
                    score += 10;
                    points = Math.Max(points, score);
                    Console.SetCursorPosition(food.x, food.y);
                    Console.Write("$");

                    while (!food.foodonWall(wall) || !food.foodonsnake(Sn))
                    {
                        food.Setrandompos();
                        Console.SetCursorPosition(food.x, food.y);
                        Console.Write("$");
                    }
                    Sn.Draw();
                    food.Draw();
                    wall.Draw();
                    Thread.Sleep(speed);
                }
                if (score == level * 50)
                {
                    Console.Clear();
                    level++;
                    wall = new Wall(level);

                    speed = Math.Max(1, speed - 100);
                }



                static void Main(string[] args)
                {
                    Thread threa = new Thread(playgame); //zmeika sama dvigaetsya
                    Console.CursorVisible = false;
                    Console.SetWindowSize(80, 30);

                    //threa.Start();

                    //int x=10, y=10; //koordinati nashei zmeiki 
                    snake Sn = new snake();
                    Wall wall = new Wall(level);
                    eda food = new eda();

                    bool gameover = false;
                    Console.WriteLine("If you want to start new game press R ");
                    Console.WriteLine("If you want to continue last game press C");
                    ConsoleKeyInfo key1 = Console.ReadKey();
                    if (key1.Key == ConsoleKey.C)
                    {
                        Sn = F2();
                        wall = F4();
                        points = F7();
                        food = F6();
                        score = Sn.cnt;
                    }

                    Console.Clear();
                    threa.Start();
                    while (!gameover) //not gameover
                    {
                        ConsoleKeyInfo key = Console.ReadKey();//podvigaem zmeikoi
                        if (key.Key == ConsoleKey.UpArrow)
                            direction = 3;//Sn.Move(0, -1);// y--;
                        if (key.Key == ConsoleKey.DownArrow)
                            direction = 4;//Sn.Move(0, 1);//y++;
                        if (key.Key == ConsoleKey.LeftArrow)
                            direction = 1; //Sn.Move(-1, 0);// x--;
                        if (key.Key == ConsoleKey.RightArrow)
                            direction = 2;// Sn.Move(1, 0);//x++;
                        if (key.Key == ConsoleKey.Escape)
                            gameover = true;
                        if (Sn.cnt == 60)
                        {
                            wall = new Wall(2);
                        }
                        if (key.Key == ConsoleKey.R) // new game
                        {
                            Console.Clear();

                            Sn = new snake();
                            level = 1;
                            score = 0;
                            wall = new Wall(level);
                            speed = 400;
                        }
                        if (key.Key == ConsoleKey.Spacebar) //probel
                        {
                            Sn.cnt = score;
                            F1(Sn);
                            F3(wall);
                            F5(food);
                            F8(points);
                        }
                        // Console.Clear();
                        /* Console.SetCursorPosition(x, y);//ustanavlivaet polojenie kursora//esli ne ustanavlivat' kursor(_) stoit na odnom meste

                         Console.Write("*");*/
                        /* Console.Clear();
                         Sn.Draw();
                         wall.Draw();
                         food.Draw();*/


                        //odin potok otvechaet na pojatie na klavishu
                        //vtoroi za dvijenie
                        //if(sn.Draw()%10) //kajdie 10 shagov
                        /*{
                            speed = Math.Max(speed - 100, 1);
                            /*speed = speed - 100;
                            if (speed < 0)
                                speed = 1;*/





                        //wall.WallDraw();
                        //snake.Draw();
                        // food.ShowFood();

                        

                    }
                }
            }
        }
    }
}



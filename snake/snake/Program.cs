using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace snake
{
    class Program
    {
        static Snake snake = new Snake();
        static int level = 1;
        static Wall wall = new Wall(level);
        static int direction = 1; // 1 - left, 2 - right, 3 - up, 4 - down;
        static int speed = 400;
        static Food food = new Food();

        static int score = 0;
        static int points = F7();
        //static ConsoleKeyInfo info;
        // static ConsoleKeyInfo key1;


        static void F1(Snake snake)
        {
            FileStream fs = new FileStream(@"C:\Users\user\c#labki\examples\lect7(snake)\data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, snake);
            fs.Close();
        }
        static Snake F2()
        {
            FileStream fs = new FileStream(@"C:\Users\user\c#labki\examples\lect7(snake)\data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Snake s = bf.Deserialize(fs) as Snake;
            fs.Close();
            return s;
        }
        static void F3(Wall wall)
        {
            FileStream fs = new FileStream(@"C:\Users\user\c#labki\examples\lect7(snake)\data1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, wall);
            fs.Close();
        }
        static Wall F4()
        {
            FileStream fs = new FileStream(@"C:\Users\user\c#labki\examples\lect7(snake)\data1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Wall w = bf.Deserialize(fs) as Wall;
            fs.Close();
            return w;
        }
        static void F5(Food food)
        {
            FileStream fs = new FileStream(@"C:\Users\user\c#labki\examples\lect7(snake)\data2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, food);
            fs.Close();
        }
        static Food F6()
        {
            FileStream fs = new FileStream(@"C:\Users\user\c#labki\examples\lect7(snake)\data1.txt\data2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Food f = bf.Deserialize(fs) as Food;
            fs.Close();
            return f;
        }
        static int F7()
        {
            StreamReader sr = new StreamReader(@"C:\Users\Compag\Desktop\PP-2\week5\SnakeGame\Snake\points.txt");
            string s = sr.ReadLine();
            sr.Close();
            return int.Parse(s);
        }
        static void F8(int a)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\Compag\Desktop\PP-2\week5\SnakeGame\Snake\points.txt");
            sw.WriteLine(a);
            sw.Close();

        }
        public static void PlayGame()
        {
            while (true)
            {
                if (direction == 1)
                {
                    snake.Move(-1, 0);
                }
                if (direction == 2)
                {
                    snake.Move(1, 0);
                }
                if (direction == 3)
                {
                    snake.Move(0, -1);
                }
                if (direction == 4)
                {
                    snake.Move(0, 1);
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("High score : " + " " + points + "   Score: " + score + " " + "Level" + " " + level);
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("If you want to save current score, enter [Probel]");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("If you want to quit, enter [Escape] ");


                if (snake.CollisionWithWall(wall) || snake.Collision())
                {
                    Console.Clear();
                    Console.SetCursorPosition(7, 7);
                    StreamReader sr = new StreamReader(@"C:\Users\Compag\Desktop\PP-2\week5\SnakeGame\Snake\gameover.txt");
                    string s = sr.ReadToEnd();
                    Console.WriteLine(s);
                    Console.WriteLine("High Score : " + " " + points + "Your Score is " + score);

                    Console.ReadKey();

                    Console.Clear();
                    speed = 400;
                    snake = new Snake();
                    level = 1;
                    wall = new Wall(level);
                    score = 0;

                    while (!food.foodonwall(wall) || !food.foononsnake(snake))
                    {
                        food.SetRandomPos();
                        Console.SetCursorPosition(food.x, food.y);
                        Console.Write("$");
                    }
                }

                if (snake.Eat(food))
                {
                    snake.AddBody();
                    food.SetRandomPos();
                    score += 10;
                    points = Math.Max(points, score);
                    Console.SetCursorPosition(food.x, food.y);
                    Console.Write("$");

                    while (!food.foodonwall(wall) || !food.foononsnake(snake))
                    {
                        food.SetRandomPos();
                        Console.SetCursorPosition(food.x, food.y);
                        Console.Write("$");
                    }

                }
                if (score == level * 50)
                {
                    Console.Clear();
                    level++;
                    wall = new Wall(level);

                    speed = Math.Max(1, speed - 100);

                    while (!food.foodonwall(wall) || !food.foononsnake(snake))
                    {
                        food.SetRandomPos();
                        Console.SetCursorPosition(food.x, food.y);
                        Console.Write("$");
                    }
                }
                // Console.Clear();
                snake.Draw();
                food.ShowFood();
                wall.WallDraw();
                Thread.Sleep(speed);

            }
        }



        static void Main(string[] args)
        {

            Thread thread = new Thread(PlayGame);
            // thread.Start();

            Console.SetWindowSize(80, 30);
            Console.CursorVisible = false;


            //level = 1;
            //score = 0;
            //points = F7();
            /*Wall wall = new Wall(level);
            Snake snake = new Snake();
            Food food = new Food();
            */

            Console.WriteLine("If you want to start new game press R ");
            Console.WriteLine("If you want to continue last game press C");
            ConsoleKeyInfo key1 = Console.ReadKey();


            if (key1.Key == ConsoleKey.C)
            {
                snake = F2();
                wall = F4();
                points = F7();
                food = F6();
                score = snake.score;
            }

            Console.Clear();
            thread.Start();
            //wall.WallDraw();
            //snake.Draw();
            // food.ShowFood();


            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("High score : " + " " + points + "   Score: " + score + " " + "Level" + " " + level);
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("If you want to save current score, enter [Probel]");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("If you want to quit, enter [Escape] ");

                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.UpArrow)
                {
                    direction = 3;
                }
                if (info.Key == ConsoleKey.DownArrow)
                {
                    direction = 4;
                }
                if (info.Key == ConsoleKey.LeftArrow)
                {
                    direction = 1;
                }
                if (info.Key == ConsoleKey.RightArrow)
                {
                    direction = 2;
                }

                if (info.Key == ConsoleKey.R) // new game
                {
                    Console.Clear();

                    snake = new Snake();
                    level = 1;
                    score = 0;
                    wall = new Wall(level);
                    speed = 400;
                }

                if (info.Key == ConsoleKey.Spacebar)
                {
                    snake.score = score;
                    F1(snake);
                    F3(wall);
                    F5(food);
                    F8(points);
                }
                if (info.Key == ConsoleKey.Escape)
                {
                    return;
                }



                /* Console.Clear();
                 snake.Draw();
                 food.ShowFood();
                 wall.WallDraw();
                 */
            }
        }
    }
    }


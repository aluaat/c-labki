using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//peremechenie i zakrashivanie ch
//enter->
namespace week3ex4
{
    
    class Program
    {
        //otdel'naya funcsia: //public static void sHOWDirectoryinfo -mi vse v oodnom klasse piwem ,mojno otpuskat' public,private 
        // static  int CONSOLE_SIZE= 30;
        static void ShowDirectoryINfo (DirectoryInfo directory,int cursor) //pokaz vsex failov i papok v dannom directory ,otdelnaya funccsia,peredaem directoryinfo
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            

            FileSystemInfo[] fss = directory.GetFileSystemInfos(); //uznat' soderjimoe //Filesysteminfo vozvrashaet i papok i failov 
            int index = 0; //kakoi fail,papka po indeksu vvodim na ekran,
            foreach(FileSystemInfo f in fss)
            {
                if(cursor==index) //znachit  nash kursor i index raven
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
               else if(f.GetType()==typeof(DirectoryInfo)) //esli ono directoryinfo 
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else //inache eto File u nas
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine(f.Name);
                index++;

                /*if (index >= first && index <= first + CONSOLE_SIZE)
                {
                    Console.WriteLine(f.Name);
                    index++;
                }*/
            }
               
        }
        
            static void Main(string[] args)
        {
            //Console.WindowHeight;
                DirectoryInfo directory = new DirectoryInfo(@"D:\C++");
             //int first = 0;
            

            //nahoodimsya na pervoi strochke
            //najimaem vniz ,i ta strochka na kotoroi mi budet zakrashivat'tsya 
            //nujno global'naya peremena ,KURSOR ==pervaya -pozicia na kotoroi mi nahodimsya
            int cursor = 0;
            ShowDirectoryINfo(directory, cursor);
            int n = directory.GetFileSystemInfos().Length; //massiv konca


            while(true) //poka bezkonechnost'
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(); //znachenie kklaviwi
                if(keyInfo.Key==ConsoleKey.UpArrow) 
                {
                    cursor--;
                    if (cursor < 0)  //esli ushel v nol
                    {
                        cursor = n - 1;
                    }
                    /*if (cursor < first)
                    {
                        //last--;
                        first--;
                    }*/
                }
               
                if (keyInfo.Key==ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor ==n)  
                    {
                        cursor = 0; //posle poslednego on budet perehodit' srazu na papku

                    }
                     /*if (cursor> first+CONSOLE_SIZE)
                    {
                       // last++;
                       // first++;
                    }
                    */
                }
                if(keyInfo.Key==ConsoleKey.Enter) //chtob' provalivat'sya v papku
                {
                     if (directory.GetFileSystemInfos()[cursor].GetType()==typeof(DirectoryInfo)) //esli papka //massiv filesystem kursor//posle togo kak mi uznali wto papka
                    {
                        // directory = new DirectoryInfo(directory.GetFileSystemInfos()[cursor].FullName); //zamenit' showfilesysteminfo
                        //new-sozdaetsya novaya peremena,yasheika
                        //no tak kak u nas est' directotyia ,prosto ssilaemsya
                        //fullname-vozrashaet polnost'u put'
                        //Directoryinfo Fylesysteminfo
                        directory = (DirectoryInfo)directory.GetFileSystemInfos()[cursor];
                        cursor = 0;
                        n = directory.GetFileSystemInfos().Length;
                       // first = 0;
                
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(directory.GetFileSystemInfos()[cursor].FullName); 
                        string s = sr.ReadToEnd(); 
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine(s);
                        Console.ReadKey();
                    }
                }

                if(keyInfo.Key==ConsoleKey.Escape)
                {
                    if (directory.Parent != null)
                    {
                        directory = directory.Parent;
                        cursor = 0;
                        n = directory.GetFileSystemInfos().Length;
                        //first = 0;


                  }
                          else
                      {
                      break;
                     }

                }
               
                ShowDirectoryINfo(directory,cursor); //posle togo kak pomenyali cursor,Console.clear doljni sdelat',owiwaet i vvodim vse faili papki
                

            }

            /*ShowDirectoryINfo(directory);
            Console.ReadKey();*/
         
        }
    }
}

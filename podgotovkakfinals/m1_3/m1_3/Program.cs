using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace m1_3
{
    class Program
    {
        static void Main(string[] args)
        {
             DirectoryInfo d = new DirectoryInfo(@"C:\Users\user\Desktop\c#");
            FileSystemInfo[] fss = d.GetFileSystemInfos();
            string s;
            Console.Clear();
            foreach (FileSystemInfo f in fss)
            {
                if (f.GetType()==typeof(FileInfo))
                {
                    s = File.ReadAllText(f.FullName);
                    if (s=="FIT")
                    {
                        Console.WriteLine(f.Name);
                    }
                   /* if (!s.Contains("FIT"))
                    {
                        Console.WriteLine("not found ");
                    }*/


                }
            }
            Console.ReadKey();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace serialcom
{
    public class Complex
    {
        public int a, b;

        public Complex()
        {
            a = 2;
            b =5;
        }

        public override string ToString()
        {
            return a + "/" + b;
        }
    }

    [Serializable]
    class Program
    {
        static void first()
        {
            FileStream fs = new FileStream(@"C:\Users\user\c#labki\out.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Complex));
            Complex complex = new Complex();

            try
            {
                xmlSerializer.Serialize(fs, complex);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("serialization completed");


        }
        static void second()
        {
            FileStream fs = new FileStream(@"C:\Users\user\c#labki\out.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Complex c = new Complex();

            XmlSerializer serializer = new XmlSerializer(typeof(Complex));
            // StreamReader streamReader = new StreamReader("data.xml");
            try
            {
                c = (Complex)serializer.Deserialize(fs);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine(c);
        }
        static void Main(string[] args)
        {
            first();
            second();
            Console.ReadKey();
        }
    }
}

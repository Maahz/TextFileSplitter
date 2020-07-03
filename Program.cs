using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace TextFileSplitter
{
    class Program
    {
        public static string outputFile = @"C:\Users\Markku\Desktop\TestDir\";
        public static string[] file;
        public static string path = "";
        public static int COUNT = 0;

        static void Main(string[] args)
        {
            
            try
            {
                file = args[0].Split('\\');
                for (int i = 0; i < file.Length - 1; i++)
                {
                    path += file[i]+"\\";
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (!Directory.Exists(path))
            {
                return;
            }

            Thread count = new Thread(() => counter(args[0]));
            count.Start();
            Console.WriteLine("Waiting for counter to finnish...");
            count.Join();
            int area = COUNT / 10;
            for (int i = 0; i < 10; i++)
            {
                Thread runner = new Thread(() => Runner(args[0],area, i));
                runner.Start();
            }
            

            Console.WriteLine("Press ENTER To Exit");
            Console.Read();
        }

        private static void counter(string path)
        {
            COUNT = File.ReadLines(path).Count();
        }

        private static void Runner(string path,int area, int id)
        {
            int start = area * id;
            for (int i = 0; i < area; i++)
            {
                try
                {
                    var firstLines = File.ReadLines(path).Skip(i * 1000000).Take(1000000).ToArray();
                    File.AppendAllLines(outputFile + "file"+id+"(" + i + 1 + ").txt", firstLines);
                    Console.Write("File: " + i + "\r");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.Read();
                    return;
                }

            }
        }
    }
}

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
            
            //Split file address to get file name
            try
            {
                file = args[0].Split('\\');
                for (int i = 0; i < file.Length - 1; i++)
                {
                    path += file[i]+"\\";  //Merge it back to new global variable for later use.
                }
            }
            catch (Exception)
            {
                throw;
            }
            //Make sure that the string recieved was a file path.
            if (!Directory.Exists(path))
            {
                return;
            }

            for (int i = 0; i >= 0; i++)
            {
                try
                {
                    //Take 1M new lines and skip the ones already appended
                    var firstLines = File.ReadLines(path).Skip(i * 1000000).Take(1000000).ToArray();
                    File.AppendAllLines(outputFile + "file(" + i + 1 + ").txt", firstLines);
                    Console.Write("File: " + i + "\r");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.Read();
                    return;
                }

            }

            Console.WriteLine("Press ENTER To Exit");
            Console.Read();
        }
    }
}

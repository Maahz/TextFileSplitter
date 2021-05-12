using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace TextFileSplitter
{
    public class Setup
    {
        public static string _outputFile = @"C:\Users\Markku\Desktop\TestDir\";
        public static string[] _file;
        public static string _path = "";
        public static int _count = 0;
    }
    class Program
    {

        static void Main(string[] args)
        {
            
            //Split file address to get file name
            try
            {
                BacksetDriver.ModifyFilePath(args);
                
            }
            catch (Exception)
            {
                throw;
            }
            //Make sure that the string recieved was a file path.
            if (!Directory.Exists(Setup._path))
            {
                return;
            }

            for (int i = 0; i >= 0; i++)
            {
                try
                {
                    //Take 1M new lines and skip the ones already appended
                    var firstLines = File.ReadLines(Setup._path).Skip(i * 1000000).Take(1000000).ToArray();
                    File.AppendAllLines(Setup._outputFile + "file(" + i + 1 + ").txt", firstLines);
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

using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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

            /**********************************************************
             * 
             * Actual magic is in here. 
             * Take part of the file and split.
             * 
             **********************************************************/
            Task[] tasks = new Task[2];
            tasks[0] = Task.Factory.StartNew(() => BacksetDriver.Work());
            tasks[1] = Task.Factory.StartNew(() => BacksetDriver.Work());

            
            Console.WriteLine("Press ENTER To Exit");
            Console.Read();
        }
    }
}

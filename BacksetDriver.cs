using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileSplitter
{
    class BacksetDriver
    {
        public static void ModifyFilePath(string[] args)
        {
            Setup._file = args[0].Split('\\');
            for (int i = 0; i < Setup._file.Length - 1; i++)
            {
                Setup._path += Setup._file[i] + "\\";  //Merge it back to new global variable for later use.
            }
        }

        internal static void Work()
        {
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
        }
    }
}

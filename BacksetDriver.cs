using System;
using System.Collections.Generic;
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
    }
}

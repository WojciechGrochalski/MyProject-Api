
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Tools
{
    public class ReadTable
    {
       
        public static string GetCurrent(string data,string NBP_Address)
        {
            
            string dane;
            string path = @""+data+".json";

            path = Path.GetFullPath(path);

            dane = File.ReadAllText(path);
            return dane;
        }

       
    }
}

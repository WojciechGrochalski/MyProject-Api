using MyProject.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Tools
{
    public class ReadTable
    {
        // GetValue myParser = new GetValue();
         static  ITools tools = new GetValue();
        public static string GetCurrent(string data,string NBP_Address)
        {
            
            tools.GetApi(data, NBP_Address);
            string dane;
            string path = @""+data+".json";

            path = Path.GetFullPath(path);

            dane = File.ReadAllText(path);
            return dane;
        }

       
    }
}

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
        public static string GetCurrent(string data,string NBP_Address)
        {
            GetValue.GetApi(data,NBP_Address);
            string dane;
            string path = @""+data+".json";
           // string path = @"Data/DolarsTable.json";
            path = Path.GetFullPath(path);

            dane = File.ReadAllText(path);
            return dane;
        }

       
    }
}

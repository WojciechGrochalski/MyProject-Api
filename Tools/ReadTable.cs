using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Tools
{
    public class ReadTable
    {
        GetValue myParser = new GetValue();
        public string GetCurrent()
        {
            myParser.GetApi();
            string dane;
            string path = @"Data/DolarsTable.json";
            path = Path.GetFullPath(path);

            dane = File.ReadAllText(path);
            return dane;
        }
    }
}

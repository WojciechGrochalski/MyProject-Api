
using MyProject.Currency;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Tools
{
    public class ReadValue
    {
        private static  List<ValueOfCurrency> listOfCurrency = new List<ValueOfCurrency>();
        public static async Task<string> GetCurrent(string iso)
        {
            iso = iso.ToUpper();
            string path = "Data/ValueOfCurrencyToday.json";
            path = Path.GetFullPath(path);
            string fileData = File.ReadAllText(path);
            listOfCurrency = JsonConvert.DeserializeObject<List<ValueOfCurrency>>(fileData);
            var result = from f in listOfCurrency
                         where f.Type == iso
                         select f;
            string res = JsonConvert.SerializeObject(result);
            await Task.CompletedTask;

            return   res;
        }

       
    }
}

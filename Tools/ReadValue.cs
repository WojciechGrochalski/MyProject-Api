
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
        private static  List<CurrencyDTO> listOfObject = new List<CurrencyDTO>();
         //static public ValueOfCurrency walute = new ValueOfCurrency();
        public static async Task<string> GetCurrent(string iso)
        {
            iso = iso.ToUpper();
            string path = "Data/ValueOfCurrencyToday.json";
            path = Path.GetFullPath(path);
            string fileData = File.ReadAllText(path);
            listOfObject = JsonConvert.DeserializeObject<List<CurrencyDTO>>(fileData);
            var result = from f in listOfObject
                         where f.Code == iso
                         select f;
            //foreach (var item in walute._listOfObject)
            //{
            //    if(item.FindIso(iso))
            //    {
            //        walute.SetValue(item);
            //    }
            //}
            // iso = iso.ToLower();
            //var ress = listOfCurrency.Find(f => f.Code.Contains(iso));
            string res = JsonConvert.SerializeObject(result);
            await Task.CompletedTask;

            return   res;
        }

       
    }
}

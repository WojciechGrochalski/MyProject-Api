using MyProject.Currency;
using MyProject.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Timers;

namespace MyProject.Tools
{
    public class ApiTools : ICurrencyRepository
    {
        readonly WebClient webClient = new WebClient();
        public ValueOfCurrency _walute = new ValueOfCurrency();
        private  List<CurrencyDTO> listOfObject = new List<CurrencyDTO>();
        private List<ValueOfCurrency> _listOfValue = new List<ValueOfCurrency>();
        private string[] isoArray;


        public ValueOfCurrency GetApiToFile(string url)
        {
            string reply = webClient.DownloadString(url);
           
            dynamic jObject = JObject.Parse(reply);
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            string name = jObject.currency;
            string code = jObject.code;
            string askPrice = jObject.rates[0].ask;
            string bidPrice = jObject.rates[0].bid;

            ValueOfCurrency _walute = new ValueOfCurrency(name,code,bidPrice,askPrice,date);
           
            return _walute;
        }

        public async Task<string> GetCurrent(string iso)
        {
            iso = iso.ToUpper();
            string path = "Data/ValueOfCurrencyToday.json";
            path = Path.GetFullPath(path);
            string fileData = File.ReadAllText(path);
            listOfObject = JsonConvert.DeserializeObject<List<CurrencyDTO>>(fileData);
            var result = from f in listOfObject
                         where f.Code == iso
                         select f;

            string res = JsonConvert.SerializeObject(result);
            await Task.CompletedTask;

            return res;
        }
        public void GetApi()
        {
            _listOfValue.Clear();

            string path = @"Data/iso.json";
            path = Path.GetFullPath(path);
            string fileData = File.ReadAllText(path);
            isoArray = JsonConvert.DeserializeObject<string[]>(fileData);
            foreach (string iso in isoArray)
            {
                string url = "http://api.nbp.pl/api/exchangerates/rates/c/" + iso + "/?today/?format=json";
                _listOfValue.Add( GetApiToFile(url));
            }

            string jsonString = JsonConvert.SerializeObject(_listOfValue, Formatting.Indented);
            path = @"Data/ValueOfCurrencyToday.json";
            path = Path.GetFullPath(path);
            File.WriteAllText(path, jsonString);
        }
    }

}

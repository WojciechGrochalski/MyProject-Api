using MyProject.Currency;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Timers;

namespace MyProject.Tools
{
    public class GetApiContiouns : GetApi
    {
        readonly WebClient webClient = new WebClient();
        readonly CultureInfo kultura1 = new CultureInfo("Pl-pl");
        public ValueOfCurrency _walute = new ValueOfCurrency();
        Timer myTimer = new Timer();
        public string Data { get; set; }
 

        public string GetApiContinous(string data)
        {
            string reply = webClient.DownloadString(Data);
            if(reply== "404 Not Found"||reply== "400 Bad Request")
            {
                return reply;
            }
            dynamic jObject = JObject.Parse(reply);
            string acctualPriceData = DateTime.Now.ToString("yyy.MM.dd ");
            string code = jObject.code;
            string askPrice = jObject.rates[0].ask;
            string bidPrice = jObject.rates[0].bid;

          //  _walute.Add(code, bidPrice, askPrice, acctualPriceData);
            string jsonString = JsonConvert.SerializeObject(_walute,Formatting.Indented);
         
            return  jsonString;
        }

        public ValueOfCurrency GetApiToFile(string data)
        {
            string reply = webClient.DownloadString(data);
           
            dynamic jObject = JObject.Parse(reply);
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            string name = jObject.currency;
            string code = jObject.code;
            string askPrice = jObject.rates[0].ask;
            string bidPrice = jObject.rates[0].bid;

            ValueOfCurrency _walute = new ValueOfCurrency(name,code,bidPrice,askPrice,date);

            return _walute;
        }

        public async Task<string> GetApiContinousAsync()
        {
            string reply = webClient.DownloadString(Data);
            if (reply == "404 Not Found" || reply == "400 Bad Request")
            {
                return reply;
            }
            dynamic jObject = JObject.Parse(reply);
            string acctualPriceData = DateTime.Now.ToString("yyyy.MM.dd ");
            string code = jObject.code;
            string askPrice = jObject.rates[0].ask;
            string bidPrice = jObject.rates[0].bid;

           // _walute.Add(code, bidPrice, askPrice, acctualPriceData);
            string jsonString = JsonConvert.SerializeObject(_walute, Formatting.Indented);
            await Task.CompletedTask;

            return  jsonString;
        }
    }

}

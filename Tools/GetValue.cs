using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;
using MyProject.Currency;

namespace MyProject.Tools
{
    public class GetValue
    {
        WebClient webClient = new WebClient();
        public ValueOfCurrency myWalute = new ValueOfCurrency();
        public List<ValueOfCurrency> myListOfWalutes = new List<ValueOfCurrency>();
        CultureInfo kultura1 = new CultureInfo("Pl-pl");
        
        public void GetApi()
        {
            string jsonString = "";

            string reply = webClient.DownloadString("http://api.nbp.pl/api/exchangerates/rates/c/usd/2016-04-04/?format=json");

            dynamic jObject = JObject.Parse(reply);

            myWalute.type = jObject.code;
            myWalute.bidPrice = jObject.rates[0].bid;
            myWalute.askPrice = jObject.rates[0].ask;
            myWalute.acctualPriceData = DateTime.Now.ToLocalTime().ToString("MM.dd HH:mm:ss");

            myListOfWalutes.Insert(0,myWalute);
            string path = @"Data/DolarsTable.json";
            path = Path.GetFullPath(path);
            string fileData = File.ReadAllText(path);

            if (fileData != "")
            {
                int counter = 0;
               List<ValueOfCurrency> lastWalutes= JsonConvert.DeserializeObject<List<ValueOfCurrency>>(fileData);
                foreach (ValueOfCurrency item in lastWalutes)
                {
                    myListOfWalutes.Add(item);
                    counter++;
                    if(counter==9)
                    {
                        break;
                    }
                }

               
            }
         
             jsonString = System.Text.Json.JsonSerializer.Serialize(myListOfWalutes);
            File.WriteAllText(path, jsonString);
        }


    }
}

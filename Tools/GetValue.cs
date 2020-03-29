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
       static WebClient webClient = new WebClient();
       static public ValueOfCurrency myWalute = new ValueOfCurrency();
        static public List<ValueOfCurrency> myListOfWalutes = new List<ValueOfCurrency>();
        static public List<ValueOfCurrency> helpListOfWalutes = new List<ValueOfCurrency>();
        CultureInfo kultura1 = new CultureInfo("Pl-pl");
        
        public static void GetApi(string data,string NBP_Address)
        {
            myListOfWalutes.Clear();
            helpListOfWalutes.Clear();
         

            string reply = webClient.DownloadString(NBP_Address);

            dynamic jObject = JObject.Parse(reply);

            myWalute.type = jObject.code;
            myWalute.bidPrice = jObject.rates[0].bid;
            myWalute.askPrice = jObject.rates[0].ask;
            myWalute.acctualPriceData = DateTime.Now.ToLocalTime().ToString("MM.dd HH:mm:ss");

            myListOfWalutes.Add(myWalute);
            string path = @"" + data +".json";
            path = Path.GetFullPath(path);
            string fileData = File.ReadAllText(path);

            if (fileData != "")
            {
                int counter = 0;
                helpListOfWalutes= JsonConvert.DeserializeObject<List<ValueOfCurrency>>(fileData);
                
                foreach (ValueOfCurrency item in helpListOfWalutes)
                {
                   
                    myListOfWalutes.Add(item);
                    counter++;
                    if (counter == 9)
                    {
                        break;
                    }

                } 
            }
              
            string jsonString = System.Text.Json.JsonSerializer.Serialize(myListOfWalutes);
            File.WriteAllText(path, jsonString);
        }


    }
}

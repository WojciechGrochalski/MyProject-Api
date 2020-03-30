using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;
using MyProject.Currency;
using MyProject.Repository;

namespace MyProject.Tools
{
    public class GetValue:ITools
    {
         readonly WebClient webClient = new WebClient();
         readonly CultureInfo kultura1 = new CultureInfo("Pl-pl");

         public ValueOfCurrency myWalute = new ValueOfCurrency();
         public List<ValueOfCurrency> myListOfWalutes=new List<ValueOfCurrency>();
         public List<ValueOfCurrency> helpListOfWalutes = new List<ValueOfCurrency>();
        
        
        public void GetApi(string data,string NBP_Address)
        {
            myListOfWalutes.Clear();
            helpListOfWalutes.Clear();
            string reply = webClient.DownloadString(NBP_Address);

            dynamic jObject  = JObject.Parse(reply);
            string acctualPriceData = DateTime.Now.ToLocalTime().ToString("MM.dd HH:mm:ss");
            string code = jObject.code;
            string askPrice = jObject.rates[0].ask;
            string bidPrice = jObject.rates[0].bid;

      
            myWalute.Add(code, bidPrice, askPrice, acctualPriceData);
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

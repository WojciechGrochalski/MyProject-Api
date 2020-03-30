using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Currency
{
    public class ValueOfCurrency
    {
        public string Type { get;  set; }
        public string BidPrice { get; set; }
        public string AskPrice { get; set; }
        public string AcctualPriceData { get;  set; }

        public ValueOfCurrency()
        {

        }
        public ValueOfCurrency(string type,string bidPrice,string askPrice,string acctualPriceData)
        {
            Type = type;
            BidPrice = bidPrice;
            AskPrice = askPrice;
            AcctualPriceData = acctualPriceData;
        }

        public void Add(string type, string bidPrice, string askPrice, string acctualPriceData)
        {
            Type = type;
            BidPrice = bidPrice;
            AskPrice = askPrice;
            AcctualPriceData = acctualPriceData;

        }

      
    }
}

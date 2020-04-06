using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Currency
{
    public class CurrencyDTO
    {
        public string Name { get;  set; }
        public string Code { get; set; }
        public string BidPrice { get;  set; }
        public string AskPrice { get; set; }
        public string Data { get; set; }
    }
}

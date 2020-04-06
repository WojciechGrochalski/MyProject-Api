using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Currency
{
    public class ValueOfCurrency
    {
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public string BidPrice { get; protected set; }
        public string AskPrice { get; protected set; }
        public string Data { get; set; }
        List<ValueOfCurrency> _listOfObject = new List<ValueOfCurrency>();
        public ValueOfCurrency()
        {

        }
        public ValueOfCurrency(string name ,string code,string bidPrice,string askPrice,string data)
        {
            SetName(name);
            SetCode (code);
            SetBidPrice (bidPrice);
            SetAskPrice (askPrice);
            SetData (data);
        }

        public void SetValueList(List<ValueOfCurrency> listwalute)
        {
            _listOfObject.AddRange(listwalute);
        }

        public void SetValue(ValueOfCurrency walute)
        {
            SetName(walute.Name);
            SetCode(walute.Code);
            SetBidPrice(walute.BidPrice);
            SetAskPrice(walute.AskPrice);
            SetData(walute.Data);
        }


        public bool FindIso(string iso)
        {
            if(iso==Code)
            {
                return true;
            }
            return false;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetCode(string code)
        {
            Code = code;
        }
        public void SetBidPrice(string bidPrice)
        {
            BidPrice = bidPrice;
        }
        public void SetAskPrice(string askPrice)
        {
            AskPrice = askPrice;
        }
        public void SetData(string data)
        {
            Data = data;
        }




    }
}

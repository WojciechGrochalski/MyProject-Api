using MyProject.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Repository
{
   public  interface ICurrencyRepository
    {
        Task<string> GetCurrent(string iso);
        ValueOfCurrency GetApiToFile(string url);
        void GetApi();
    }
}

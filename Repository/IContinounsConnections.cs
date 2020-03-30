using MyProject.Currency;
using MyProject.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public interface IContinounsConnections
    {
       
        Task<string> AsyncGetApiContinous();
    }
}

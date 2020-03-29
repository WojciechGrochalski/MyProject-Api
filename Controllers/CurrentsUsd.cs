using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Tools;

namespace MyProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentsUsd : ControllerBase
    {
       
        //[HttpGet("{eur}")]
        
        //public string GetEuro()
        //{
        //    return  ReadTable.GetCurrent("Data/EuroTable", "http://api.nbp.pl/api/exchangerates/rates/c/eur/?format=json"); 
        //}

        [HttpGet]
        
        public string GetDolars()
        {
            return ReadTable.GetCurrent("Data/DolarsTable", "http://api.nbp.pl/api/exchangerates/rates/c/usd/?format=json");
        }
    }
}

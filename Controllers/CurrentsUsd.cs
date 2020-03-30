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
        GetApiContiouns getApiContiouns = new GetApiContiouns("http://api.nbp.pl/api/exchangerates/rates/c/usd/today/?format=json");

        [HttpGet]

        public string GetDolars()
        {
            return ReadTable.GetCurrent("Data/DolarsTable", "http://api.nbp.pl/api/exchangerates/rates/c/usd/today/?format=json");
        }

        [HttpGet("now")]
        public async Task<string> GetDolarsContinousAsync()
        {
           
            return await getApiContiouns.AsyncGetApiContinous();
        }
    }
}

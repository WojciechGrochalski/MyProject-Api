using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Tools;


namespace MyProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentsUsd : ControllerBase
    {

        static GetApiContiouns getApiContiouns = new GetApiContiouns("http://api.nbp.pl/api/exchangerates/rates/c/usd/?today/?format=json");
        GetApi getApi = new GetApi();

        [HttpGet]

        public async Task<string> GetDolars()
        {
            return await getApi.GetApiAsync("Data/DolarsTable", "http://api.nbp.pl/api/exchangerates/rates/c/usd/?today/?format=json");
        }




        [HttpGet("now")]
        public async Task<string> GetDolarsContinousAsync()
        {
            
            return await getApiContiouns.GetApiContinousAsync();
        }



    }
}


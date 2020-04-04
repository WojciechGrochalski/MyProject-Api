using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Tools;

namespace MyProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllCurrents : ControllerBase
    {


        [HttpGet("{iso}")]
        public async Task<string> GetWaluteContinousAsync(string iso)
        {
            string url = "http://api.nbp.pl/api/exchangerates/rates/c/" + iso + "/?today/?format=json";
            GetApiContiouns getApiContiouns = new GetApiContiouns(url);


            return await getApiContiouns.GetApiContinousAsync();
        }



    }
}
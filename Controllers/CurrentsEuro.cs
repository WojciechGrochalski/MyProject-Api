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
    public class CurrentsEuro : ControllerBase
    {
        GetApi getApi = new GetApi();

        [HttpGet]
        public async Task<string> GetEuro()
        {
            return  await getApi.GetApiAsync("Data/EuroTable", "http://api.nbp.pl/api/exchangerates/rates/c/eur/?today/?format=json");
        }

     
    }
}

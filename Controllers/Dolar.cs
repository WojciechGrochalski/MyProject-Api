using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Repository;
using MyProject.Tools;


namespace MyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Dolar : ControllerBase
    {
        private ICurrencyRepository _currencyRepository;

        public Dolar(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        [HttpGet]
        public async Task<string> GetDolars()
        {
            return await _currencyRepository.GetCurrentToday("USD");
        }

        [HttpGet("now")]
        public async Task<string> GetDolarsContinousAsync()
        {
            return await _currencyRepository.GetCurrentToday( "usd");
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Repository;
using MyProject.Tools;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Euro : ControllerBase
    {
        private ICurrencyRepository _currencyRepository;

        public Euro(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        [HttpGet]
        public async Task<string> GetEuro()
        {
            return await _currencyRepository.GetCurrent("eur");
        }

     
    }
}

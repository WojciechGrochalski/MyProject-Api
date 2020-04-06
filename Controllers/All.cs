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
    public class All : ControllerBase
    {

        private ICurrencyRepository _currencyRepository;
        public All(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }
        [HttpGet("{iso}")]
        public async Task<string> GetWaluteContinousAsync(string iso)
        {
            return await _currencyRepository.GetCurrent(iso);
        }
    }
}
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
    [Route("api/[controller]")]
    public class Dolar : ControllerBase
    {

        [HttpGet]

        public async Task<string> GetDolars()
        {
            return await ReadValue.GetCurrent("usd");
        }

        [HttpGet("now")]
        public async Task<string> GetDolarsContinousAsync()
        {
            return await ReadValue.GetCurrent( "usd");
        }

    }
}


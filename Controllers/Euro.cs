using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MyProject.Tools;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Euro : ControllerBase
    {

        [HttpGet]
        public async Task<string> GetEuro()
        {
            return await ReadValue.GetCurrent("eur");
        }

     
    }
}

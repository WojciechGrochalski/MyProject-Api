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
    public class All : ControllerBase
    {

        [HttpGet("{iso}")]
        public async Task<string> GetWaluteContinousAsync(string iso)
        {
            return await ReadValue.GetCurrent(iso);
        }
    }
}
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
    public class TestContrroler : ControllerBase
    {
       
        [HttpGet]
        public string Get()
        {
         
            ReadTable read = new ReadTable();
           
            return  read.GetCurrent(); 
        }
    }
}

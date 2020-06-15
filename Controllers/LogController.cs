using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsLibraryApi.Repostitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarsLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRepostiory logRepostiory;
        

        public LogController(ILogRepostiory logRepostiory)
        {
            this.logRepostiory = logRepostiory;
        }

        [HttpGet("GetLogs")]
        public async Task<string> GetLogs()
        {
            var logs = await logRepostiory.GetLogs();
            return Serialize(logs);
        }

       

        public string Serialize<TParam>(TParam obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceA.Controllers
{
    [Route("api/ServiceA")]
    [ApiController]
    public class ServiceTestAController : ControllerBase
    {
    
        [HttpGet, Route("")]
        public ActionResult<IEnumerable<string>> Get()
        {
        return new string[] { "DaemonService" , "TaskService" ,"ExecutionService" };
        }
    }
}

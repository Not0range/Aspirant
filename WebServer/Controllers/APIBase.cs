using Database;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class APIBase : Controller
    {
        protected readonly AspirantDBContext _ctx;

        protected readonly ILogger _logger;

        public APIBase(AspirantDBContext ctx, ILogger logger)
        {
            _ctx = ctx;
            _logger = logger;
        }
    }
}

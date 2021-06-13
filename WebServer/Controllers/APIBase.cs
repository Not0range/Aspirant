using Database;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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

        public APIBase(AspirantDBContext ctx)
        {
            _ctx = ctx;
        }
    }
}

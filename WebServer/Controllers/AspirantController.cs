using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Controllers
{
    [ApiController]
    public class AspirantController : APIBase
    {
        public AspirantController(Database.AspirantDBContext ctx) : base(ctx) { }

        public ActionResult<Aspirant> Get()
        {
            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = _ctx.People.FirstOrDefault(i => i.UserId == id);

            var aspirant = _ctx.Aspirants.FirstOrDefault(i => i.PersonId == person.Id);
            if (aspirant == null)
                return NotFound();
            return aspirant;
        }
    }
}

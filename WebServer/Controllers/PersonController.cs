using Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Controllers
{
    [ApiController]
    public class PersonController : APIBase
    {
        public PersonController(Database.AspirantDBContext ctx) : base(ctx) { }

        public ActionResult<Person> Get()
        {
            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = _ctx.People.FirstOrDefault(i => i.UserId == id);
            if (person == null)
                return NotFound();
            return person;
        }
    }
}

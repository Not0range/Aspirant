using Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Controllers
{
    [ApiController]
    public class PersonController : APIBase
    {
        public PersonController(Database.AspirantDBContext ctx) : base(ctx) { }

        [HttpGet]
        public async Task<ActionResult<Person>> Get()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return NotFound();
            return person;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PersonAddForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person != null)
                return BadRequest();

            person = form.GetPerson();
            person.UserId = id;
            await _ctx.People.AddAsync(person);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody] PersonEditForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return NotFound();

            form.GetPerson(person);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}

using Database.Entities;
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
    public class AspirantController : APIBase
    {
        public AspirantController(Database.AspirantDBContext ctx) : base(ctx) { }

        [HttpGet]
        public async Task<ActionResult<Aspirant>> Get()
        {
            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return NotFound();

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
                return NotFound();
            return aspirant;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AspirantAddForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person != null)
                return BadRequest();

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant != null)
                return BadRequest();

            aspirant = form.GetAspirant();
            aspirant.PersonId = person.Id;
            await _ctx.People.AddAsync(person);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody] AspirantEditForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return NotFound();

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
                return NotFound();

            form.GetAspirant(aspirant);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}

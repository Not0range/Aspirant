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
    public class EnducationController : APIBase
    {
        public EnducationController(Database.AspirantDBContext ctx) : base(ctx) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enducation>>> Get()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            return await _ctx.Enducations.Where(i => i.PersonId == person.Id).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Enducation>> Get(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int userId;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out userId))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == userId);
            if (person == null)
                return BadRequest();

            return await _ctx.Enducations.FirstOrDefaultAsync(i => i.PersonId == person.Id && i.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Add(EnducationAddForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            var enducation = form.GetEnducation();
            enducation.PersonId = person.Id;
            await _ctx.Enducations.AddAsync(enducation);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EnducationEditForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            var enducation = await _ctx.Enducations.FirstOrDefaultAsync(i => i.Id == form.Id && i.PersonId == person.Id);
            if (enducation == null)
                return BadRequest();

            form.GetEnducation(enducation);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteObject obj)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            var enducation = await _ctx.Enducations.FirstOrDefaultAsync(i => i.Id == obj.Id && i.PersonId == person.Id);
            if (enducation == null)
                return BadRequest();

            _ctx.Enducations.Remove(enducation);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}

using Database.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Controllers
{
    [ApiController]
    [EnableCors("Policy")]
    public class EnducationController : APIBase
    {
        public EnducationController(Database.AspirantDBContext ctx, ILogger<EnducationController> logger) : base(ctx, logger) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enducation>>> Get()
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get enudcation list");
            if (!User.Identity.IsAuthenticated)
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            _logger.LogDebug($"UserId: {id}");
            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
            {
                _logger.LogDebug($"Person not found");
                return BadRequest();
            }

            _logger.LogDebug($"PersonId: {person.Id}");
            return await _ctx.Enducations.Where(i => i.PersonId == person.Id).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Enducation>> Get(int id)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get enudcation ({id})");
            if (!User.Identity.IsAuthenticated)
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            int userId;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out userId))
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            _logger.LogDebug($"UserId: {userId}");
            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == userId);
            if (person == null)
            {
                _logger.LogDebug($"Person not found");
                return BadRequest();
            }

            _logger.LogDebug($"PersonId: {person.Id}");
            return await _ctx.Enducations.FirstOrDefaultAsync(i => i.PersonId == person.Id && i.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Add(EnducationAddForm form)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting create enudcation");
            if (!User.Identity.IsAuthenticated)
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            _logger.LogDebug($"UserId: {id}");
            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
            {
                _logger.LogDebug($"Person not found");
                return BadRequest();
            }

            _logger.LogDebug($"PersonId: {person.Id}");
            var enducation = form.GetEnducation();
            enducation.PersonId = person.Id;
            await _ctx.Enducations.AddAsync(enducation);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EnducationEditForm form)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting edit enudcation");
            if (!User.Identity.IsAuthenticated)
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            _logger.LogDebug($"UserId: {id}");
            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
            {
                _logger.LogDebug($"Person not found");
                return BadRequest();
            }

            _logger.LogDebug($"PersonId: {person.Id}");
            var enducation = await _ctx.Enducations.FirstOrDefaultAsync(i => i.Id == form.Id && i.PersonId == person.Id);
            if (enducation == null)
            {
                _logger.LogDebug($"Enducation not found");
                return BadRequest();
            }

            form.GetEnducation(enducation);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteObject obj)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting delete enudcation");
            if (!User.Identity.IsAuthenticated)
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
            {
                _logger.LogDebug($"Unauthorized");
                return Unauthorized();
            }

            _logger.LogDebug($"UserId: {id}");
            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
            {
                _logger.LogDebug($"Person not found");
                return BadRequest();
            }

            _logger.LogDebug($"PersonId: {person.Id}");
            var enducation = await _ctx.Enducations.FirstOrDefaultAsync(i => i.Id == obj.Id && i.PersonId == person.Id);
            if (enducation == null)
            {
                _logger.LogDebug($"Enducation not found");
                return BadRequest();
            }

            _ctx.Enducations.Remove(enducation);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}

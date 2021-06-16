using Database.Entities;
using Microsoft.AspNetCore.Cors;
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
    public class AspirantController : APIBase
    {
        public AspirantController(Database.AspirantDBContext ctx, ILogger<AspirantController> logger) : base(ctx, logger) { }

        [HttpGet]
        public async Task<ActionResult<Aspirant>> Get()
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get aspirant");
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
                return NotFound();
            }

            _logger.LogDebug($"PersonId: {person.Id}");
            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
            {
                _logger.LogDebug($"Aspirant not found");
                return NotFound();
            }
            return aspirant;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AspirantAddForm form)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting create aspirant");
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
            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant != null)
            {
                _logger.LogDebug($"Aspirant found. Bad request");
                return BadRequest();
            }

            aspirant = form.GetAspirant();
            aspirant.PersonId = person.Id;
            await _ctx.Aspirants.AddAsync(aspirant);
            await _ctx.SaveChangesAsync();
            _logger.LogDebug($"Aspirant added ({aspirant.Id})");
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody] AspirantEditForm form)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting edit aspirant");
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
                return NotFound();
            }

            _logger.LogDebug($"PersonId: {person.Id}");
            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
            {
                _logger.LogDebug($"Aspirant not found");
                return NotFound();
            }

            form.GetAspirant(aspirant);
            await _ctx.SaveChangesAsync();
            _logger.LogDebug($"Aspirant edited ({aspirant.Id})");
            return Ok();
        }
    }
}

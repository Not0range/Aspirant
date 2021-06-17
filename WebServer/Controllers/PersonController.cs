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
    public class PersonController : APIBase
    {
        public PersonController(Database.AspirantDBContext ctx, ILogger<PersonController> logger) : base(ctx, logger) { }

        [HttpGet]
        public async Task<ActionResult<Person>> Get()
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get person");
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
            _logger.LogDebug($"Person found ({person.Lastname} {person.Firstname} {person.Patronymic})");
            return person;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> GetAt(int id)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get persons list");
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

            if (!User.IsInRole("admin"))
                return Forbid();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.Id == id);
            if (person == null)
            {
                _logger.LogDebug($"Person not found");
                return NotFound();
            }
            _logger.LogDebug($"Person found ({person.Lastname} {person.Firstname} {person.Patronymic})");
            return person;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get persons list");
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

            if (!User.IsInRole("admin"))
                return Forbid();

            return await _ctx.People.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PersonAddForm form)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting create person");
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
            if (person != null)
            {
                _logger.LogDebug($"Person found. Bad request");
                return BadRequest();
            }

            person = form.GetPerson();
            person.UserId = id;
            await _ctx.People.AddAsync(person);
            await _ctx.SaveChangesAsync();
            _logger.LogDebug($"Person added ({person.Lastname} {person.Firstname} {person.Patronymic})");
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody] PersonEditForm form)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting edit person");
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

            form.GetPerson(person);
            await _ctx.SaveChangesAsync();
            _logger.LogDebug($"Person edited ({person.Lastname} {person.Firstname} {person.Patronymic})");
            return Ok();
        }
    }
}

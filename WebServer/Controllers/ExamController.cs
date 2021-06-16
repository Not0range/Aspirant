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
    public class ExamController : APIBase
    {
        public ExamController(Database.AspirantDBContext ctx, ILogger<ExamController> logger) : base(ctx, logger) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> Get()
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get exams list");
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
            if (aspirant == null)
            {
                _logger.LogDebug($"Aspirant not found");
                return BadRequest();
            }

            _logger.LogDebug($"AspirantId: {aspirant.Id}");
            return await _ctx.Exams.Where(i => i.AspirantId == aspirant.Id).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Exam>> Get(int id)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get exam ({id})");
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
            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
            {
                _logger.LogDebug($"Aspirant not found");
                return BadRequest();
            }

            _logger.LogDebug($"AspirantId: {aspirant.Id}");
            return await _ctx.Exams.FirstOrDefaultAsync(i => i.AspirantId == aspirant.Id && i.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ExamAddForm form)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting add exam");
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

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
            {
                _logger.LogDebug($"Person not found");
                return BadRequest();
            }

            _logger.LogDebug($"PersonId: {person.Id}");
            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
            {
                _logger.LogDebug($"Aspirant not found");
                return BadRequest();
            }

            _logger.LogDebug($"AspirantId: {aspirant.Id}");
            var exam = form.GetExam();
            exam.AspirantId = aspirant.Id;
            await _ctx.Exams.AddAsync(exam);
            await _ctx.SaveChangesAsync();
            _logger.LogDebug($"Exam added ({exam.Id})");
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ExamEditForm form)
        {
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

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
            {
                _logger.LogDebug($"Person not found");
                return BadRequest();
            }

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
            {
                _logger.LogDebug($"Aspirant not found");
                return BadRequest();
            }

            var exam = await _ctx.Exams.FirstOrDefaultAsync(i => i.Id == form.Id && i.AspirantId == aspirant.Id);
            if (exam == null)
            {
                _logger.LogDebug($"Exam not found");
                return BadRequest();
            }

            form.GetExam(exam);
            await _ctx.SaveChangesAsync();
            _logger.LogDebug($"Exam edited ({exam.Id})");
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteObject obj)
        {
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

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
            {
                _logger.LogDebug($"Person not found");
                return BadRequest();
            }

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
            {
                _logger.LogDebug($"Aspirant not found");
                return BadRequest();
            }
            
            var exam = await _ctx.Exams.FirstOrDefaultAsync(i => i.Id == obj.Id && i.AspirantId == aspirant.Id);
            if (exam == null)
            {
                _logger.LogDebug($"Exam not found");
                return BadRequest();
            }

            _ctx.Exams.Remove(exam);
            await _ctx.SaveChangesAsync();
            _logger.LogDebug($"Exam deleted ({exam.Id})");
            return Ok();
        }
    }
}

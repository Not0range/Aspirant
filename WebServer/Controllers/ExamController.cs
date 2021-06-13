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
    public class ExamController : APIBase
    {
        public ExamController(Database.AspirantDBContext ctx) : base(ctx) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> Get()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
                return BadRequest();

            return await _ctx.Exams.Where(i => i.AspirantId == aspirant.Id).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Exam>> Get(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int userId;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out userId))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == userId);
            if (person == null)
                return BadRequest();

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
                return BadRequest();

            return await _ctx.Exams.FirstOrDefaultAsync(i => i.AspirantId == aspirant.Id && i.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ExamAddForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
                return BadRequest();

            var exam = form.GetExam();
            exam.AspirantId = aspirant.Id;
            await _ctx.Exams.AddAsync(exam);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ExamEditForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
                return BadRequest();

            var exam = await _ctx.Exams.FirstOrDefaultAsync(i => i.Id == form.Id && i.AspirantId == aspirant.Id);
            if (exam == null)
                return BadRequest();

            form.GetExam(exam);
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

            var aspirant = await _ctx.Aspirants.FirstOrDefaultAsync(i => i.PersonId == person.Id);
            if (aspirant == null)
                return BadRequest();
            
            var exam = await _ctx.Exams.FirstOrDefaultAsync(i => i.Id == obj.Id && i.AspirantId == aspirant.Id);
            if (exam == null)
                return BadRequest();

            _ctx.Exams.Remove(exam);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}

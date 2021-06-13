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
    public class EntryExamController : APIBase
    {
        public EntryExamController(Database.AspirantDBContext ctx) : base(ctx) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryExam>>> Get()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            return await _ctx.EntryExams.Where(i => i.PersonId == person.Id).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<EntryExam>> Get(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int userId;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out userId))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == userId);
            if (person == null)
                return BadRequest();

            return await _ctx.EntryExams.FirstOrDefaultAsync(i => i.PersonId == person.Id && i.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] EntryExamAddForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            var exam = form.GetExam();
            exam.PersonId = person.Id;
            await _ctx.EntryExams.AddAsync(exam);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody] EntryExamEditForm form)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            int id;
            if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
                return Unauthorized();

            var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            if (person == null)
                return BadRequest();

            var exam = await _ctx.EntryExams.FirstOrDefaultAsync(i => i.Id == form.Id && i.PersonId == person.Id);
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

            var exam = await _ctx.EntryExams.FirstOrDefaultAsync(i => i.Id == obj.Id && i.PersonId == person.Id);
            if (exam == null)
                return BadRequest();

            _ctx.EntryExams.Remove(exam);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}

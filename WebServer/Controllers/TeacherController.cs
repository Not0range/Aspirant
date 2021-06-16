﻿using Database.Entities;
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
    public class TeacherController : APIBase
    {
        public TeacherController(Database.AspirantDBContext ctx, ILogger<TeacherController> logger) : base(ctx, logger) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> Get()
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get teachers list");
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
            return await _ctx.Teachers.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Teacher>> GetAt(int id)
        {
            _logger.LogDebug($"[{DateTime.Now}]Attempting get teacher ({id})");
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
            return await _ctx.Teachers.FirstOrDefaultAsync(i => i.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TeacherAddForm form)
        {
            //_logger.LogDebug($"[{DateTime.Now}]Attempting create entry exam");
            //if (!User.Identity.IsAuthenticated)
            //{
            //    _logger.LogDebug($"Unauthorized");
            //    return Unauthorized();
            //}

            //int id;
            //if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
            //{
            //    _logger.LogDebug($"Unauthorized");
            //    return Unauthorized();
            //}

            //_logger.LogDebug($"UserId: {id}");
            //var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            //if (person == null)
            //{
            //    _logger.LogDebug($"Person not found");
            //    return BadRequest();
            //}

            //_logger.LogDebug($"PersonId: {person.Id}");
            //var exam = form.GetExam();
            //exam.PersonId = person.Id;
            //await _ctx.EntryExams.AddAsync(exam);
            //await _ctx.SaveChangesAsync();
            //_logger.LogDebug($"Exam added ({exam.Id})");
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody] TeacherEditForm form)
        {
            //_logger.LogDebug($"[{DateTime.Now}]Attempting edit entry exam");
            //if (!User.Identity.IsAuthenticated)
            //{
            //    _logger.LogDebug($"Unauthorized");
            //    return Unauthorized();
            //}

            //int id;
            //if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
            //{
            //    _logger.LogDebug($"Unauthorized");
            //    return Unauthorized();
            //}

            //_logger.LogDebug($"UserId: {id}");
            //var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            //if (person == null)
            //{
            //    _logger.LogDebug($"Person not found");
            //    return BadRequest();
            //}

            //_logger.LogDebug($"PersonId: {person.Id}");
            //var exam = await _ctx.EntryExams.FirstOrDefaultAsync(i => i.Id == form.Id && i.PersonId == person.Id);
            //if (exam == null)
            //{
            //    _logger.LogDebug($"Exam not found");
            //    return BadRequest();
            //}

            //form.GetExam(exam);
            //await _ctx.SaveChangesAsync();
            //_logger.LogDebug($"Exam edited ({exam.Id})");
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteObject obj)
        {
            //_logger.LogDebug($"[{DateTime.Now}]Attempting delete entry exam");
            //if (!User.Identity.IsAuthenticated)
            //{
            //    _logger.LogDebug($"Unauthorized");
            //    return Unauthorized();
            //}

            //int id;
            //if (!int.TryParse(User.Claims.FirstOrDefault(i => i.Type == "ID").Value, out id))
            //{
            //    _logger.LogDebug($"Unauthorized");
            //    return Unauthorized();
            //}

            //var person = await _ctx.People.FirstOrDefaultAsync(i => i.UserId == id);
            //if (person == null)
            //{
            //    _logger.LogDebug($"Person not found");
            //    return BadRequest();
            //}

            //var exam = await _ctx.EntryExams.FirstOrDefaultAsync(i => i.Id == obj.Id && i.PersonId == person.Id);
            //if (exam == null)
            //{
            //    _logger.LogDebug($"Exam not found");
            //    return BadRequest();
            //}

            //_ctx.EntryExams.Remove(exam);
            //await _ctx.SaveChangesAsync();
            //_logger.LogDebug($"Exam deleted ({exam.Id})");
            return Ok();
        }
    }
}
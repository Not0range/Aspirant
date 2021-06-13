using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebServer.Pages
{
    public class PersonModel : PageModel
    {
        AspirantDBContext _ctx;

        public Person Person { get; set; }

        public PersonModel(AspirantDBContext context, IHttpContextAccessor contextAccessor)
        {
            _ctx = context;
            if (contextAccessor.HttpContext.User.Claims.Count() > 0)
            {
                int id = int.Parse(contextAccessor.HttpContext.User.Claims.First(i => i.Type == "ID").Value);
                var person = _ctx.People.FirstOrDefault(i => i.UserId == id);
                Person = person;
            }
        }
        public ActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("/");
            return Page();
        }
    }
}

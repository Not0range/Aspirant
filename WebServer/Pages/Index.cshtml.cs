using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Database;
using Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebServer.Pages
{
    public class IndexModel : PageModel
    {
        AspirantDBContext _ctx;

        private readonly IHttpClientFactory _clientFactory;

        public Person Person { get; set; }

        public IndexModel(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _clientFactory = clientFactory;
            if (contextAccessor.HttpContext.User.IsInRole("admin"))
            {
                
            }
        }
        
        public ActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                HttpContext.Response.StatusCode = 401;
            return Page();
        }
    }
}

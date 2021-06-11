using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebServer.Pages
{
    public class IndexModel : PageModel
    {

        public IndexModel()
        {
                
        }
        
        public void OnGet()
        {
            if(!User.Identity.IsAuthenticated)
                HttpContext.Response.StatusCode = 401;
        }
    }
}

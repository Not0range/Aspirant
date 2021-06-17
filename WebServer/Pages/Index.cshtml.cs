using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Database;
using Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebServer.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IHttpClientFactory _clientFactory;

        public JArray People { get; set; }

        public JArray Teachers { get; set; }

        public IndexModel(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _clientFactory = clientFactory;
            if (contextAccessor.HttpContext.User.IsInRole("admin"))
            {
                var client = _clientFactory.CreateClient("controllers");
                var msg = new HttpRequestMessage(HttpMethod.Get, "/api/person/getall");
                msg.Headers.Add("Cookie", contextAccessor.HttpContext.Request.Headers["Cookie"].ToString());
                string str = "";
                client.Send(msg).Content.ReadAsStringAsync().ContinueWith(r => str = r.Result).Wait();
                People = JsonConvert.DeserializeObject<JArray>(str);

                msg = new HttpRequestMessage(HttpMethod.Get, "/api/teacher/get");
                msg.Headers.Add("Cookie", contextAccessor.HttpContext.Request.Headers["Cookie"].ToString());
                str = "";
                client.Send(msg).Content.ReadAsStringAsync().ContinueWith(r => str = r.Result).Wait();
                Teachers = JsonConvert.DeserializeObject<JArray>(str);
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

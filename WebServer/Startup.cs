using Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            services.AddDbContext<AspirantDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AspirantDb")));
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = ctx =>
                {
                    var logger = ctx.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("Console");
                    logger.LogDebug($"Client Error: {ctx.HttpContext.Request.Method} {ctx.HttpContext.Request.Path} \n" +
                    $"{{ {string.Join(", ", ctx.ModelState.Select(p => $"{p.Key}: {p.Value.AttemptedValue}"))} }}");
                    return new BadRequestObjectResult(ctx.ModelState);
                };
            });
            services.AddRazorPages();
            services.AddCors(options =>
            {
                options.AddPolicy("Policy", builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:19006");
                });
            });
            services.AddHttpContextAccessor();
            services.AddHttpClient("controllers", c => c.BaseAddress = new Uri("http://127.0.0.1/"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            });

            app.UseStaticFiles();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}

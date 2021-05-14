using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CoreAndFood
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            services.AddMvc(Config =>//buras� t�m controllera eri�imin login i�lemi i�ermesi i�in
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                Config.Filters.Add(new AuthorizeFilter(policy));
            });


            // kullan�c� giri� ��k�� i�lemleri i�in
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";//giri� yap�lmam�� ise bu sayfaya at�l�r
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();//login i�lemi i�in
            app.UseRouting();
            app.UseAuthorization();// login olmadan giri�leri engelleme i�lemi i�in
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });






            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

        }
    }
}

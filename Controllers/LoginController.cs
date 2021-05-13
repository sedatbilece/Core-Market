using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class LoginController : Controller {

         Context c=new Context();

        [AllowAnonymous]// tüm sayfayı euth işleminde uygularken bunun muaf olmasını sağlar
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
         var dataval = c.Admins.FirstOrDefault (x => x.UserName == admin.UserName && x.Password == admin.Password);


            
            if (dataval != null) {


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , admin.UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal pri = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(pri);

                return RedirectToAction("Index","Category");
            }


            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {


            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}

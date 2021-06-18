using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDepartmanProje.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CoreDepartmanProje.Controllers
{
    public class Login : Controller
    {
        
        Context c = new Context();
       
       [HttpGet]
        public IActionResult ILogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>ILogin(Admin p)
        {
            var knowns = c.Admins.FirstOrDefault(x => x.userName == p.userName && x.Password == p.Password);
            if (knowns != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.userName)
                };
            var userIdentity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
            }
            return View();
        }
    }
}

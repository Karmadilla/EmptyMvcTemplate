using EmptyTemplate.Business;
using EmptyTemplate.DataAccess;
using EmptyTemplate.Models.Account;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace EmptyTemplate.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserManager userManager = new UserManager();
            User user = userManager.GetUser(model.Email);

            if (user != null && (user.Password == model.Password)) // TODO: Don't store plain-text passwords.
            {
                List<System.Security.Claims.Claim> claims = new List<System.Security.Claims.Claim>();
                claims.Add(new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
                claims.Add(new System.Security.Claims.Claim(ClaimTypes.Email, user.Email));
                claims.Add(new System.Security.Claims.Claim(ClaimTypes.Name, user.Username));
                claims.Add(new System.Security.Claims.Claim("password", user.Password));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie");

                Request.GetOwinContext().Authentication
                    .SignIn(
                        new AuthenticationProperties()
                        {
                            IsPersistent = true
                        }, claimsIdentity);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
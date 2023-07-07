using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.Models;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.ViewModel;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Register(RegisterVM rmv)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passwdHash = Crypto.HashPassword(rmv.Password);
                var user = new AppUser()
                {
                    Email = rmv.Email,
                    UserName = rmv.Username,
                    PasswordHash = passwdHash,
                    City = rmv.City,
                    Birthday = rmv.DateOfBirth,
                    Address = rmv.Address,
                    PhoneNumber = rmv.Mobile
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("myError", "Invalid username and password");
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Login lvm)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ModelState.AddModelError("myError", "Invalid username and password");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
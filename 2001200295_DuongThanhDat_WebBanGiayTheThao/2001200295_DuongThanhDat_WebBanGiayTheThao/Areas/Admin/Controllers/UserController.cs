using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.Identity;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.Models;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
    }
}
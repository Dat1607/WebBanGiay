using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.Models;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        DBContext db = new DBContext();
        public ActionResult Index()
        {
            List<Category> cat = db.Categories.ToList();
            return View(cat);
        }
    }
}
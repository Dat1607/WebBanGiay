using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.Models;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Controllers
{
    public class ProController : Controller
    {
        // GET: Pro
        DBContext db = new DBContext();
        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }
    }
}
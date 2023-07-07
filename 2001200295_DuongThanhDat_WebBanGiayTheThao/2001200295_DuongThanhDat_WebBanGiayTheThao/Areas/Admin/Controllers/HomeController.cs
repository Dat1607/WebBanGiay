using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.Models;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        DBContext db = new DBContext();
        public ActionResult Index()
        {
            return View();
        }
        // Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("Index","Product");
        }
        // Edit
        public ActionResult Edit(int id)
        {
            Product pro = db.Products.Where(row => row.Id == id).FirstOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            Product pro = db.Products.Where(row => row.Id == product.Id).FirstOrDefault();
            pro.Name = product.Name;
            pro.Price = product.Price;
            pro.Description = product.Description;
            pro.CatId = product.CatId;
            pro.ImageUrl = product.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        // Delete
        public ActionResult Delete(int id)
        {
            Product pro = db.Products.Where(row => row.Id == id).FirstOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult Delete(int id,Product product)
        {
            Product pro = db.Products.Where(row => row.Id == id).FirstOrDefault();
            db.Products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
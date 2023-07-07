using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.Models;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DBContext db = new DBContext();
        public ActionResult Index(string sort,string Search = "",int page = 1)
        {
            // Search
            List<Product> products = db.Products.Where(row => row.Name.Contains(Search)).ToList();
            ViewBag.Search = Search;
            // Sort
            switch (sort)
            {
                case "Giam":
                    products = products.OrderByDescending(row => row.Price).ToList();
                    break;
                case "Tang":
                    products = products.OrderBy(row => row.Price).ToList();
                    break;
                default:
                    break;
            }
            // Paging
            int NoOfRecordPerpage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerpage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerpage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerpage).ToList();
            return View(products);
        }

        public ActionResult Detail(int id)
        {
            Product de = db.Products.Where(row => row.Id == id).FirstOrDefault();
            return View(de);
        }
        public ActionResult Sort(string sort)
        {
            List<Product> products = db.Products.ToList();
            switch (sort)
            {
                case "id":
                    products = products.OrderByDescending(row => row.Id).ToList();
                    break;
                case "name":
                    products = products.OrderBy(row => row.Name).ToList();
                    break;
                default:
                    break;
            }

            return View(products);
        }
    }
}
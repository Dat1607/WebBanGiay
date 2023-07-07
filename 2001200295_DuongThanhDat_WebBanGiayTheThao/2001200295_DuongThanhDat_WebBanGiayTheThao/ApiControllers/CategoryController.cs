using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2001200295_DuongThanhDat_WebBanGiayTheThao.Models;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.ApiControllers
{
    public class CategoryController : ApiController
    {
        public List<Category> Get()
        {
            DBContext db = new DBContext();
            List<Category> cat = db.Categories.ToList();
            return cat;
        }
    }
}

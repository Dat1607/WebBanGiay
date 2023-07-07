using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("MyCS") { }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
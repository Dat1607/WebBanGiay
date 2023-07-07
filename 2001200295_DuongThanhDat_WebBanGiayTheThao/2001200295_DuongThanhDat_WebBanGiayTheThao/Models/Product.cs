using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Models
{
    public class Product
    {
        [Key]
        public  long Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long CatId { get; set; }
        public string ImageUrl { get; set; }
        public virtual Category Category { get; set; }
    }
}
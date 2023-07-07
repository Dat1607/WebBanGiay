using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Models
{
    public class Category
    {
        [Key]
        public long CatId { get; set; }
        public string Name { get; set; }
    }
}
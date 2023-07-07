using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "Tên tài khoản không được để trống!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password không được để trống!")]
        public string Password { get; set; }
    }
}
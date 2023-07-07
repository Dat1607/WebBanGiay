using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Tên tài khoản không được để trống!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password không được để trống!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Xác thực password không được để trống!")]
        [Compare("Password", ErrorMessage = "password và password xác thực không trùng khớp!")]
        public string ComfirmPassword { get; set; }

        [Required(ErrorMessage = "Email không được để trống!")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
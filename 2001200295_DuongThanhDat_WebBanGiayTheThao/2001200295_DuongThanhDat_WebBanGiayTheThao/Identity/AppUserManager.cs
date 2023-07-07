using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity.EntityFramework;

namespace _2001200295_DuongThanhDat_WebBanGiayTheThao.Identity
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store) { }
    }
}
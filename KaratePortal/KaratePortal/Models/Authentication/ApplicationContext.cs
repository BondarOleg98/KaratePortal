using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KaratePortal.Models.Authentication;

namespace KaratePortal.Models.Authentication
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() :
        base("DefaultConnection")
        { }
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

    }
}
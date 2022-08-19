using El_Lo2ma_AccessModel.Constants;
using El_Lo2ma_DomainModel.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_AccessModel.Seeds
{
    public static class SeedRoles
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>()
                 .HasData(                 
                    new ApplicationRole(){Name=Roles.Admin},
                    new ApplicationRole(){Name=Roles.Chief},
                    new ApplicationRole(){Name=Roles.Delivery},
                    new ApplicationRole(){Name=Roles.Client}
                 );
        }
    }
}

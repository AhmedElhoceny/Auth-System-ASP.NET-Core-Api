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
    public static class SeedData
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
            modelBuilder.Entity<UserType>()
                .HasData(
                    new UserType() {Id = 1 , Name = Roles.Admin ,Licenses = "",ExpirationTime = 24},
                    new UserType() {Id = 2 , Name = Roles.Chief , Licenses = "شهادة صحية , صور البطاقة",ExpirationTime = 8 },
                    new UserType() {Id = 3 , Name = Roles.Delivery, Licenses = "رخصة قيادة , صور البطاقة", ExpirationTime = 24 },
                    new UserType() {Id = 4 , Name = Roles.Client, Licenses = "", ExpirationTime = 8 }
                );
        }
    }
}

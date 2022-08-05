using El_Lo2ma_DomainModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_AccessModel.Contexts
{
    public class Lo2maContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public Lo2maContext(DbContextOptions<Lo2maContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSofra>()
                .HasKey(bc => new { bc.Sofra_Id, bc.User_Id });
            modelBuilder.Entity<UserSofra>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.Sofra)
                .HasForeignKey(bc => bc.User_Id);
            modelBuilder.Entity<UserSofra>()
                .HasOne(bc => bc.Sofra)
                .WithMany(c => c.Users)
                .HasForeignKey(bc => bc.Sofra_Id);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Location> OrderLocations { get; set; }
        public DbSet<Sofra> Sofra { get; set; }
        public DbSet<UserSofra> UserSofra { get; set; }
        public DbSet<UserType> UserType { get; set; }
    }
}

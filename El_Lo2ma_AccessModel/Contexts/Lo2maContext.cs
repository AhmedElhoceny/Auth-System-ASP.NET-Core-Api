using El_Lo2ma_AccessModel.Extensions;
using El_Lo2ma_AccessModel.Seeds;
using El_Lo2ma_DomainModel.Models.Auth;
using El_Lo2ma_DomainModel.Models.Chief;
using El_Lo2ma_DomainModel.Models.Clients;
using El_Lo2ma_DomainModel.Models.Delivery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Models;

namespace El_Lo2ma_AccessModel.Contexts
{
    public class Lo2maContext : IdentityDbContext<ApplicationUser, IdentityRole,string,ApplicationUserClaims,ApplicationUserRole,ApplicationUserLogin,ApplicationRoleClaims,ApplicationUserToken>
    {
        private readonly IHttpContextAccessor _accessor;

        public Lo2maContext(DbContextOptions<Lo2maContext> options, IHttpContextAccessor accessor) :base(options)
        {
            _accessor = accessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            modelBuilder.Seed();


            modelBuilder.Entity<ApplicationUser>(user =>
            {
                user.HasMany(x => x.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(x => x.UserId).IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(Role =>
            {
                Role.HasMany(x => x.UserRoles)
                .WithOne(y => y.Role)
                .HasForeignKey(x => x.RoleId).IsRequired();
            });
        }

        #region dbsets
        public DbSet<Achievments> Achievments { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<TransactionLocation> TransactionLocation { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<Meel> Meels { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<TongueMeel> TongueMeels { get; set; }
        public DbSet<ChiefPayment> ChiefPayment { get; set; }
        public DbSet<Feast> Feast { get; set; }
        public DbSet<Gradient> Gradients { get; set; }
        public DbSet<Negociation_Feast> NegociationFeast { get; set; }
        public DbSet<Sofra> Sofra { get; set; }
        public DbSet<DeliveryPayment> DeliveryPayment { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<AuthCode> AuthCode { get; set; }
        #endregion

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {


            DateTime dateNow =DateTime.Now;
            string userId = _accessor!.HttpContext == null ? "" : _accessor!.HttpContext!.User.GetUserId();

            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified
                        || e.State == EntityState.Deleted)
                        );

            foreach (var entityEntry in entries)
            {



                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).InsertDate = dateNow;
                    ((BaseEntity)entityEntry.Entity).InsertBy = userId;                }
                if (entityEntry.State == EntityState.Deleted)
                {
                    entityEntry.State = EntityState.Modified;
                    ((BaseEntity)entityEntry.Entity).DeleteDate = dateNow;
                    ((BaseEntity)entityEntry.Entity).DeleteBy = userId;
                    ((BaseEntity)entityEntry.Entity).IsDeleted = true;
                    ((BaseEntity)entityEntry.Entity).UpdateDate = dateNow;
                    ((BaseEntity)entityEntry.Entity).UpdateBy = userId;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }


    }

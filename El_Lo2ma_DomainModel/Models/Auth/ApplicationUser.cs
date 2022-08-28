using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Interfaces;

namespace El_Lo2ma_DomainModel.Models.Auth
{
    public class ApplicationUser : IdentityUser, IBaseEntity
    {
        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
        public DateTime InsertDate { get ; set; }
        public DateTime UpdateDate { get ; set; }
        public DateTime? DeleteDate { get; set; }
        public string? InsertBy { get  ; set ; }
        public string? UpdateBy { get ; set ; }
        public string? DeleteBy { get ; set ; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public int UserType_Id { get; set; }
        [ForeignKey(nameof(UserType_Id))]
        public UserType UserType { get; set; }
        public ICollection<RefreshToken> RefreshTokenList { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace El_Lo2ma_DomainModel.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public long UserType_Id { get; set; }
        [ForeignKey(nameof(UserType_Id))]
        public UserType UserType { get; set; }
        public long Rate { get; set; }
        public bool IsActive { get; set; } = true;
        public string? UserToken { get; set; }
        public List<UserSofra> Sofra { get; set; }
    }
}

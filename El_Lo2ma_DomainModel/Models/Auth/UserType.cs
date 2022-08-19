using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Models;

namespace El_Lo2ma_DomainModel.Models.Auth
{
    public class UserType:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double ExpirationTime { get; set; }
        public string Licenses { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}

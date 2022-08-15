using El_Lo2ma_DomainModel.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Models;

namespace El_Lo2ma_DomainModel.Models.Clients
{
    public class TongueMeel:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public string Meel { get; set; }
        public string Description { get; set; }
        public List<ApplicationUser> ChiefUsers { get; set; }
        public DateTime Time { get; set; }
        public string MeelTitle { get; set; }
    }
}

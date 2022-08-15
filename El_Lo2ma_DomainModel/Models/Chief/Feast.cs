using El_Lo2ma_DomainModel.Models.Auth;
using El_Lo2ma_DomainModel.Models.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Models;

namespace El_Lo2ma_DomainModel.Models.Chief
{
    public class Feast:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public List<Meel> Meels { get; set; }
        public string Description { get; set; }
        public bool IsAccepted { get; set; }
        public string ChiefUserId { get; set; }
        [ForeignKey(nameof(ChiefUserId))]
        public ApplicationUser ChiefUser { get; set; }
        public double Price { get; set; }
        public DateTime RecieveDateTime { get; set; }
    }
}

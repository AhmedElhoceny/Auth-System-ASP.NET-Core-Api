using El_Lo2ma_DomainModel.Models.Auth;
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
    public class ChiefPayment:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string ChiefUserId { get; set; }
        [ForeignKey(nameof(ChiefUserId))]
        public ApplicationUser ChiefUser { get; set; }
        public double Wallet { get; set; }
        public DateTime Time { get; set; }
        public double Ponus { get; set; }
    }
}

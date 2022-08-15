using El_Lo2ma_DomainModel.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Models;

namespace El_Lo2ma_DomainModel.Models.Delivery
{
    public class DeliveryPayment:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string DeliveryUserId { get; set; }
        [ForeignKey(nameof(DeliveryUserId))]
        public ApplicationUser DeliveryUser { get; set; }
        public double Wallet { get; set; }
        public DateTime Time { get; set; }
        public double Ponus { get; set; }
    }
}

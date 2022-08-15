using El_Lo2ma_DomainModel.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Models;

namespace El_Lo2ma_DomainModel.Models.Clients
{
    public class TransactionLocation:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string DelivetyUserId { get; set; }
        [ForeignKey(nameof(DelivetyUserId))]
        public ApplicationUser DeliveryUser { get; set; }
        public DateTime Time { get; set; }
        public double Money { get; set; }
    }
}

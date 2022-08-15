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
    public class OrderDetail:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public int  MeelId { get; set; }
        [ForeignKey(nameof(MeelId))]
        public Meel Meel { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
    }
}

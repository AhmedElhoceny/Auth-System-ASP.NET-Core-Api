using El_Lo2ma_DomainModel.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Models;

namespace El_Lo2ma_DomainModel.Models.Clients
{
    public class Order:BaseEntity
    {
        public int Id { get; set; }
        public string ClientUserId { get; set; }
        [ForeignKey(nameof(ClientUserId))]
        public ApplicationUser ClientUser { get; set; }
        public string DeliveryUserId { get; set; }
        [ForeignKey(nameof(DeliveryUserId))]
        public ApplicationUser DelivaryUser { get; set; }
        public string ChiefUserId { get; set; }
        [ForeignKey(nameof(ChiefUserId))]
        public ApplicationUser ChiefUser { get; set; }
        public double X_Chief { get; set; }
        public double Y_Chief { get; set; }
        public double X_Client { get; set; }
        public double Y_Client { get; set; }
        public List<TransactionLocation> Transactions { get; set; }
        public double TotalPrice { get; set; }
        public string OrderType { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}

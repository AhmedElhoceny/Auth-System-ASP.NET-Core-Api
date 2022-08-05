using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Models
{
    public class Order
    {
        public long Id { get; set; }
        public int Chief_Id { get; set; }
        public int Delivary_Id { get; set; }
        public long Bill_Id { get; set; }
        [ForeignKey(nameof(Bill_Id))]
        public Bill Bill { get; set; }
        public DateTime RecieveDateTime { get; set; }
        public DateTime SendDateTime { get; set; }
        public DateTime DoneDateTime { get; set; }
        public double ChiefRate { get; set; }
        public double DelivaryRate { get; set; }
        public double ClientRate { get; set; }
    }
}

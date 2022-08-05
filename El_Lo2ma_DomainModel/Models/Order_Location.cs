using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Models
{
    public class Order_Location
    {
        public long Id { get; set; }
        public long Order_Id { get; set; }
        [ForeignKey(nameof(Order_Id))]
        public Order Order { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public DateTime LocationTime { get; set; }
    }
}

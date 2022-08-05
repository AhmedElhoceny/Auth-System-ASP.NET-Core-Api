using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Models
{
    public class Bill
    {
        public long Id { get; set; }
        public double FoodMoney { get; set; }
        public double DelivaryMoney { get; set; }
        public double AppMoney { get; set; }
        public double TotalMoney { get; set; }
    }
}

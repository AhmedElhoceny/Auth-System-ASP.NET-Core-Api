using El_Lo2ma_DomainModel.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Models;

namespace El_Lo2ma_DomainModel.Models.Chief
{
    public class Sofra:BaseEntity
    {
        public int Id { get; set; }
        public List<Meel> Meels { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public List<Gradient> Gradients { get; set; }
        public string Type { get; set; }
        public long Count { get; set; }
        public bool IsReady { get; set; }
        public bool Chief_Is_Active { get; set; }
    }
}

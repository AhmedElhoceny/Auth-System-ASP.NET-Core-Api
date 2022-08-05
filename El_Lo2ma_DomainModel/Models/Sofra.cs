using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Models
{
    public class Sofra
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public List<UserSofra> Users { get; set; }
    }
}

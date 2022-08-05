using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Models
{
    public class UserSofra
    {
        public int User_Id { get; set; }
        public long Sofra_Id { get; set; }
        [ForeignKey(nameof(User_Id))]
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(Sofra_Id))]
        public Sofra Sofra { get; set; }
    }
}

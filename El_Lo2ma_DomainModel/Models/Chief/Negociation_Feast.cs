using El_Lo2ma_DomainModel.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Models.Chief
{
    public class Negociation_Feast
    {
        [Key]
        public int Id { get; set; }
        public Feast Feast { get; set; }
        public double Price { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string ToUserId { get; set; }
        [ForeignKey(nameof(ToUserId))]
        public ApplicationUser ToUser { get; set; }
        public string FromUserId { get; set; }
        [ForeignKey(nameof(FromUserId))]
        public ApplicationUser FromUser { get; set; }
    }
}

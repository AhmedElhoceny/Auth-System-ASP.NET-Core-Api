using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.Domain.Models;

namespace El_Lo2ma_DomainModel.Models.Auth
{
    public class AuthCode : BaseEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        public string code { get; set; }
        public bool IsActive { get; set; }
    }
}

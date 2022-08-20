using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Models.Auth
{
    public class RefreshToken
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; } = DateTime.UtcNow.AddHours(8);
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}

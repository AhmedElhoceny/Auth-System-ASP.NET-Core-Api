using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Models
{
    public class UserType
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public int ExoirationTime { get; set; }
    }
}

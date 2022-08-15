using System.ComponentModel.DataAnnotations;
using UtilitiesManagement.Domain.Interfaces;

namespace  UtilitiesManagement.Domain.Models
{
    public class BaseEntity:IBaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }
        [StringLength(100)]
        public string? InsertBy { get; set; }
        [StringLength(100)]
        public string? UpdateBy { get; set; }
        [StringLength(100)]
        public string? DeleteBy { get; set; }
    }
}

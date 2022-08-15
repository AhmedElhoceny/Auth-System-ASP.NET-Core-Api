using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  UtilitiesManagement.Domain.Interfaces
{
    public  interface IBaseEntity
    {
        public bool IsDeleted { get; set; } 
        public DateTime InsertDate { get; set; } 
        public DateTime UpdateDate { get; set; } 
        public DateTime? DeleteDate { get; set; }
        [StringLength(100)]
        public string? InsertBy { get; set; }
        [StringLength(100)]
        public string? UpdateBy { get; set; }
        [StringLength(100)]
        public string? DeleteBy { get; set; }

    }
}

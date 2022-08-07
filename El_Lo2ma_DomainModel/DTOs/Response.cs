using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.DTOs
{
    public class Response<EntityType>  where EntityType : class
    {
        public long IdOfAddedObject { get; set; }
        public int ErrorsCount { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsExists { get; set; }
        public bool IsNotFound { get; set; }
        public bool IsNotificationSuccess { get; set; }
        public int TotalPages { get; set; }
        public EntityType Data { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}

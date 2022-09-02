using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.DTOs.Requests.Auth
{
    public class SendMailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}

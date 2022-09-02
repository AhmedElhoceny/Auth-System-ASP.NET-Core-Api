using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.DTOs
{
    public class MailSettings
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string PassWord { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}

using El_Lo2ma_DomainModel.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_Services.IServices.General
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string mailto,string subject ,string body , List<IFormFile>? attachments = null
            );
    }
}

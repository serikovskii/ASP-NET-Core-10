using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.IServices
{
    public interface IEmailSenderServices
    {
        Task SendEmail(EmailMessageDTO emailMessage);
    }
}

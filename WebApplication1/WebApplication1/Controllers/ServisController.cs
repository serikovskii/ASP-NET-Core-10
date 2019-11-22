using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;
using WebApplication1.IServices;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServisController : ControllerBase
    {
        //public IEntitySaverService Service { get; set; } 1 способ, но не передаст инициализацию

        private readonly IEntitySaverService entitySaverService;
        private readonly ISmsSenderServices smsSenderServices;
        private readonly IEmailSenderServices emailSenderServices;
        public ServisController(IEntitySaverService entitySaverService, ISmsSenderServices smsSenderServices, IEmailSenderServices emailSenderServices) 
        {
            this.entitySaverService = entitySaverService;
            this.emailSenderServices = emailSenderServices;
            this.smsSenderServices = smsSenderServices;
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(EntityDTO entity)
        {
            //var entitySaver = new EntitySaverService();
            //await entitySaver.SaveEntity(entity);

            //await Service.SaveEntity(entity);

            await entitySaverService.SaveEntity(entity);

            return Ok();
        }
        [Route("~/api/SendEmail")]
        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailMessageDTO emailMessage)
        {
            await emailSenderServices.SendEmail(emailMessage);
            return Ok();
        }
        [Route("~/api/SendSms")]
        [HttpPost]
        public async Task<IActionResult> SendSms(SmsMessageDTO smsMessage)
        {
            await smsSenderServices.SendSms(smsMessage);
            return Ok();
        }
    }
}
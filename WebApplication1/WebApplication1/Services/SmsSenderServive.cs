using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using WebApplication1.DTOs;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class SmsSenderServive : ISmsSenderServices
    {
        public Task SendSms(SmsMessageDTO smsMessage)
        {
            const string accountSid = "AC093b30d628e2cd4cb5a22f75486ee3bf";
            const string authToken = "64037bd2e3fd7c7f81a8059c44604405";
            TwilioClient.Init(accountSid, authToken);
            return MessageResource.CreateAsync(
                    body: smsMessage.Text,
                    from: new Twilio.Types.PhoneNumber("+13344544753"),
                    to: new Twilio.Types.PhoneNumber(smsMessage.To)
                );
        }
    }
}

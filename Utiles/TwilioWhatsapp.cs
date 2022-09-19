using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Utiles
{
    public class TwilioWhatsapp
    {
        public string SendMessage(string Mensaje)
        {
            string accountSid = "ACbabe7f37b78e104fc98022f33d8f5462";
            string authToken = "d59f08aee8bff2d2102739b6dadfaf0d";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: Mensaje,                
                from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                to: new Twilio.Types.PhoneNumber("whatsapp:+5491159363830")
            );

            Console.WriteLine(message.Sid);
            return message.Body;
        }
    }
}
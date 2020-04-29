using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TestTwilio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
            const string accountSid = "AC518d568c45748e383d620cb1406616fc";
            const string authToken = "3e2de6da19d791ace4b2ecd745d4c93c";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
            new PhoneNumber("+11234567890"),
            from: new PhoneNumber("+10987654321"),
            body: "Hello World!"
            );

            //var call = CallResource.Create(
            //    url: new Uri("http://demo.twilio.com/docs/classic.mp3"),
            //    to: new Twilio.Types.PhoneNumber("+380994577176"),
            //    from: new Twilio.Types.PhoneNumber("+12563715007")
            //);

            Console.WriteLine(call.Sid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Twilio.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountSecurityIdentifier = "";
            var authenticationToken = "";

            // What I personally always liked:
            //      Twilio.GetClient()
            //      .WithAccountSecurityIdentifier("")
            //      .WithAuthenticationToken("")
            //      .Init();

            TwilioClient.Init(accountSecurityIdentifier, authenticationToken);

            // What I personally always liked:
            //      Twilio.StartMessaging()
            //      .WithPhoneNumber("+XXXXXXXXXX")
            //      .From("XXXXXXXXXX")
            //      .Body("")
            //      .OtherOptions()
            //      .Build()
            // Or
            //      .Send(RetryCount: 3, Action Success, Action Success);
            // Use .NET Actions for Writing Composite Success and Error handling.

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+XXXXXXXXXX"))
            {
                From = new PhoneNumber("+XXXXXXXXXX"),
                Body = "Testing for Twilio Internship"
            };

            try
            {
                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error Occurred:");
                Console.WriteLine(exception.Message);
            }


            Console.Read();
        }
    }
}

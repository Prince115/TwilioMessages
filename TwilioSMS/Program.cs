using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;
using Twilio.Types;

namespace TwilioSMS
{
	class Program
	{
          private static string phoneNumber { get; set; }
          private static string Body { get; set; }
          private static int chooseOption { get; set; }

          //add configurations here
          private static string fromNumber = "";
          private static string MessagingServiceSid = "";
          private static string accountSid = "";
          private static string authToken = "";
          static void Main(string[] args)
		{
			Console.WriteLine("Welcome!");
			Console.WriteLine("Select the option:");
			Console.WriteLine("1. SMS");
			Console.WriteLine("2. Whatsapp");

               chooseOption = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("Please Enter sender Number..");
              
               if (chooseOption == 1)
               {
                    phoneNumber = Console.ReadLine();
               }
               else if (chooseOption == 2)
               {
                    phoneNumber = "whatsapp:" + Console.ReadLine();
               }
               else 
               {
                    Console.WriteLine("Thank you.");
               }
               var messageOptions = new CreateMessageOptions(
                  new PhoneNumber(phoneNumber));
               if (chooseOption == 1)
               {
                    //SMS
                    messageOptions.MessagingServiceSid = MessagingServiceSid;
               }
               else if (chooseOption == 2)
               {
                    messageOptions.ValidityPeriod = 20;  
                    messageOptions.MediaUrl = new System.Collections.Generic.List<Uri>() { new Uri("https://demo.twilio.com/owl.png"), new Uri("https://images.unsplash.com/photo-1541807360746-039080941306?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8cm9hZHxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60") };
                    messageOptions.From = new PhoneNumber(fromNumber);
               }

               Console.WriteLine("Write a message..");

               Body = Console.ReadLine();
               TwilioClient.Init(accountSid, authToken);

               messageOptions.Body = Body;

               var message = MessageResource.Create(messageOptions);

               Console.WriteLine("Thank you...");
               Console.WriteLine(message.Uri);
          }

	}
}

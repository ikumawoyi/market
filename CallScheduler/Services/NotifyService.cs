using CallScheduler.Interfaces;
using CallScheduler.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CallScheduler.Services
{
    
    public class NotifyService : IEmailSender, ISmsSender
    {
        public readonly IOptions<EmailSettings> _appSettings;

        public NotifyService(IOptions<EmailSettings> emailSettings, IOptions<EmailSettings> appSettings)
        {
            _emailSettings = emailSettings.Value;
            _appSettings = appSettings;
        }

        public EmailSettings _emailSettings { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {

            Execute(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public Task SendEmailAsyncTL(string email, string subject, string message, string LeadEmail)
        {

            ExecuteTL(email, subject, message, LeadEmail).Wait();
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {

            ExecuteSms(number, message).Wait();
            return Task.FromResult(0);
        }

        public async Task ExecuteSms(string number, string message)
        {
            try
            {
                //var twilioAccountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
                //var twilioAuthToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
                //TwilioClient.Init(twilioAccountSid, twilioAuthToken);

                //var message = MessageResource.Create(
                //    new PhoneNumber("+11234567890"),
                //    from: new PhoneNumber("+10987654321"),
                //    body: "Hello World!"
                //);
                //Console.WriteLine(message.Sid);
            }
            catch (Exception ex)
            {
                //do something here
            }
        }

        public async Task Execute(string email, string subject, string message)
        {
            try
            {
                // var apiKey = "YOUR SENDGRID API Key";
                var apiKey = _appSettings.Value.SendGridKey;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_appSettings.Value.UsernameEmail, "Call Scheduler Solutions");
                string toEmail = _appSettings.Value.ToEmail;
                string CcEmail = _appSettings.Value.CcEmail;


                var to = new List<EmailAddress>();
                to.Add(new EmailAddress(toEmail));
                to.Add(new EmailAddress(email));
                var plainTextContent = Regex.Replace(message, "<[^>]*>", "");
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, message);
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                //do something here
            }
        }

        public async Task ExecuteTL(string email, string subject, string message, string LeadEmail)
        {
            try
            {
                // var apiKey = "YOUR SENDGRID API Key";
                var apiKey = _appSettings.Value.SendGridKey;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_appSettings.Value.UsernameEmail, "Call Scheduler Solutions");
                string toEmail = _appSettings.Value.ToEmail;
                string CcEmail = _appSettings.Value.CcEmail;
                // LeadEmail = _appSettings.Value.LeadEmail; 


                var to = new List<EmailAddress>();
                to.Add(new EmailAddress(toEmail));
                to.Add(new EmailAddress(email));
                to.Add(new EmailAddress(LeadEmail));
                var plainTextContent = Regex.Replace(message, "<[^>]*>", "");
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, message);
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                //do something here
            }
        }
    }
}

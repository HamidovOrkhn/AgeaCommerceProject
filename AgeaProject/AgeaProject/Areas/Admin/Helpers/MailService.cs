using AgeaProject.Models;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AgeaProject.Areas.Admin.Helpers
{
    public class MailService
    {
        private static readonly MailSettings _mailSettings;
        private static readonly IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
        static MailService()
        {
            _mailSettings = new MailSettings
            {
                DisplayName = _configuration["MailSettings:DisplayName"],
                Host = _configuration["MailSettings:Host"],
                Mail = _configuration["MailSettings:Mail"],
                Password = _configuration["MailSettings:Password"],
                Port = int.Parse(_configuration["MailSettings:Port"])
            };
        }
        public static async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}

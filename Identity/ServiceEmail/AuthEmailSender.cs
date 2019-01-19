﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Identity.ServiceEmail
{
    public class AuthEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("yoursmtpserver")
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("yourusername", "yourpassword")
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("account-security-noreply@yourdomain.com")
            };
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = htmlMessage;
            return client.SendMailAsync(mailMessage);
        }
    }
}

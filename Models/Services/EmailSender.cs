using Azure.Core;
using E_commerce.Models.Interface;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace E_commerce.Models.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string HtmlMessage)
        {
            string apiKey = _configuration["SendGrid:Key"];
            var client = new SendGridClient(apiKey);
            SendGridMessage msg = new SendGridMessage();

            string fromEmailAddress = _configuration["SendGrid:DefaultFromEmailAddress"];
            string fromName = _configuration["SendGrid:DefaultFromName"];
            msg.SetFrom(fromEmailAddress, fromName);

            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, HtmlMessage);

        var res=    await client.SendEmailAsync(msg);

        }
    }
}

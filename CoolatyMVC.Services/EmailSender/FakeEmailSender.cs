using Microsoft.AspNetCore.Identity.UI.Services;

namespace CoolatyMVC.Services.EmailSender
{
    public class FakeEmailSender : IEmailSender
    {
        Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}

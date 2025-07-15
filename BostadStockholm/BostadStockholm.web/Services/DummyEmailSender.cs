using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace BostadStockholm.web.Services
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"Simulated email to {email}: {subject}\n{htmlMessage}");
            return Task.CompletedTask;
        }
    }
}
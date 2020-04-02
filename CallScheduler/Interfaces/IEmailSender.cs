using System.Threading.Tasks;

namespace CallScheduler.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailAsyncTL(string email, string subject, string message, string LeadEmail);
    }
}

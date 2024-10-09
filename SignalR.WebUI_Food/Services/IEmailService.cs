namespace SignalR.WEB_Food.Services
{
    public interface IEmailService
    {

        Task SendResetPasswordEmail(string resetPasswordEmailLink, string ToEmail);
    }
}

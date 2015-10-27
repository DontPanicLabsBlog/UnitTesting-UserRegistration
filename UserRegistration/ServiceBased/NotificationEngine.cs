using System.Net.Mail;

namespace UserRegistration
{
    public class NotificationEngine : INotificationEngine
    {
        public void NotifyNewlyRegisteredUser(User user)
        {
            var mail = new MailMessage("welcome@yourcompany.com", user.EmailAddress);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = "We're glad to have you!";
            mail.Body = "Welcome to the site!";
            client.Send(mail);
        }
    }
}
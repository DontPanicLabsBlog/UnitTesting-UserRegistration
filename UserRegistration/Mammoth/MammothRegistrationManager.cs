using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration
{
    public class MammothRegistrationManager
    {
        public void ProcessUserRegistration(long userId)
        {
            bool shouldNotifyUser = false;
            string email = "";

            using (var conn = new SqlConnection("connection_string"))
            {
                var sql = @"select PrefersNotification, EmailAddress
                            from dbo.Users
                            where Id = @Id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("Id", userId));

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            shouldNotifyUser = (bool)reader["PrefersNotification"];
                            email = (string)reader["EmailAddress"];
                        }
                    }
                }
            }

            if (shouldNotifyUser)
            {
                var mail = new MailMessage("welcome@yourcompany.com", email);
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
}

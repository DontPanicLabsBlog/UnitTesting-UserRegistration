using System.Data.SqlClient;

namespace UserRegistration
{
    public class UserRepository : IUserRepository
    {
        public User FindUserById(long userId)
        {
            User result = null;

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
                        while (reader.Read())
                        {
                            result = new User
                            {
                                Id = userId,
                                PrefersNotifications = (bool)reader["PrefersNotification"],
                                EmailAddress = (string)reader["EmailAddress"]
                            };
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
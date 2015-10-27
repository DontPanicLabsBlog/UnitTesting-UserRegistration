using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DontPanic.Helpers;

namespace UserRegistration
{
    public class RegistrationManager : ServiceBase, IRegistrationManager
    {
        public void ProcessUserRegistration(long userId)
        {
            var user = Factory.Proxy<IUserRepository>().FindUserById(userId);

            if (user.PrefersNotifications)
            {
                Factory.Proxy<INotificationEngine>().NotifyNewlyRegisteredUser(user);
            }            
        }
    }
}

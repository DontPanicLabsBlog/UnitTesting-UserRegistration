using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration
{
    public interface INotificationEngine
    {
        void NotifyNewlyRegisteredUser(User user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration
{
    public interface IRegistrationManager
    {
        void ProcessUserRegistration(long userId);
    }
}

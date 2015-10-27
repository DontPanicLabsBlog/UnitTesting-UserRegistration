using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration
{
    public interface IUserRepository
    {
        User FindUserById(long userId);
    }
}

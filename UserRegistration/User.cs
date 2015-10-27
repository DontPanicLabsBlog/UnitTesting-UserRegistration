using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration
{
    public class User
    {
        public long Id { get; set; }

        public string EmailAddress { get; set; }

        public bool PrefersNotifications { get; set; }
    }
}

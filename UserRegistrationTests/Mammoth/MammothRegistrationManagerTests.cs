using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration;

namespace UserRegistrationTests
{
    [TestClass]
    public class MammothRegistrationManagerTests
    {
        [TestMethod]
        public void ProcessUserRegistration()
        {
            var manager = new MammothRegistrationManager();

            // Good luck testing this! You will need a full-fledged database set up, populated with data, and
            // also need an email server or provider.
            manager.ProcessUserRegistration(1);            
        }
    }
}

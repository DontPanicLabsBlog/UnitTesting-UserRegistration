using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserRegistration;

namespace UserRegistrationTests
{
    [TestClass]
    public class RegistrationManagerTests
    {
        private RegistrationManager manager;

        [TestInitialize]
        public void TestInitialize()
        {
            manager = new RegistrationManager();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            manager = null;
        }

        [TestMethod]
        public void ProcessUserRegistration_VerifyNotificationNotSent_WhenUserDoesNotPrefer()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            var mockNotificationService = new Mock<INotificationEngine>();

            mockUserRepository.Setup(a => a.FindUserById(1))
                              .Returns(new User()
                              {
                                  Id = 1,
                                  PrefersNotifications = false,
                                  EmailAddress = "email@hotmail.com"
                              });

            manager.Factory.AddProxyOverride<IUserRepository>(mockUserRepository.Object);
            manager.Factory.AddProxyOverride<INotificationEngine>(mockNotificationService.Object);

            // Act
            manager.ProcessUserRegistration(1);

            // Assert
            mockUserRepository.Verify(a => a.FindUserById(1), Times.Once());

            mockNotificationService.Verify(a => a.NotifyNewlyRegisteredUser(It.IsAny<User>()), Times.Never(), "The user does not prefer email notification, so do not welcome them to the site.");
        }

        [TestMethod]
        public void ProcessUserRegistration_VerifyNotificationSent_WhenUserDoesPrefer()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            var mockNotificationService = new Mock<INotificationEngine>();

            mockUserRepository.Setup(a => a.FindUserById(2))
                              .Returns(new User()
                              {
                                  Id = 2,
                                  PrefersNotifications = true,
                                  EmailAddress = "email@hotmail.com"
                              });

            manager.Factory.AddProxyOverride<IUserRepository>(mockUserRepository.Object);
            manager.Factory.AddProxyOverride<INotificationEngine>(mockNotificationService.Object);

            // Act
            manager.ProcessUserRegistration(2);

            // Assert
            mockUserRepository.Verify(a => a.FindUserById(2), Times.Once());

            mockNotificationService.Verify(a => a.NotifyNewlyRegisteredUser(It.IsAny<User>()), Times.Once(), "A newly registered user should receive an email if they prefer notifications.");
        }
    }
}

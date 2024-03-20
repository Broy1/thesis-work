using FimaService.FimaEmailService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FimaPortalTest
{
    public class EmailTest
    {
        private IFimaEmailService _emailService;

        [SetUp]
        public void Setup()
        {
            _emailService = new FimaEmailService();
        }

        [Test]
        public void TestSendEmail()
        {
            // Arrange
            string userEmail = "testuser@gmail.com";
            string emailSubject = "Test email subject";
            string messageBody = "Test email body";

            // Act
            _emailService.SendEmail(userEmail, emailSubject, messageBody);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void TestSendEmailToUser() 
        {
            // Arrange
            string userEmail = "testuser@gmail.com";
            string emailSubject = "Test email subject";
            string messageBody = "Test email body";

            // Act
            _emailService.SendEmailToUser(userEmail, emailSubject, messageBody);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void TestSendEmailToSeller()
        {
            // Arrange
            string sellerEmail = "testuser@gmail.com";
            string productName = "video card";
            string emailText = "Test email body";

            // Act
            _emailService.SendEmailToSeller(emailText, sellerEmail, productName);

            // Assert
            Assert.Pass();
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestSendEmailWithEmptyAndNullUserAddress(string userEmail)
        {
            // Arrange
            string emailSubject = "item found";
            string messageBody = "Test email body";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => _emailService.SendEmail(userEmail, emailSubject, messageBody));

            // Assert
            Assert.That(ex.ParamName, Is.EqualTo("userEmail"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestSendEmailWithEmptyAndNullEmailBody(string messageBody)
        {
            // Arrange
            string userEmail = "testemail@gmail.com";
            string emailSubject = "item found";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => _emailService.SendEmail(userEmail, emailSubject, messageBody));

            // Assert
            Assert.That(ex.ParamName, Is.EqualTo("messageBody"));
        }
    }
}

using DemoSalesApp.Models;
using FilterManagerPortal.Areas.Identity.Data;
using FilterManagerPortal.Repository;
using FimaService.FimaEmailService;
using Microsoft.CodeAnalysis;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FimaPortalTest
{
    public class LogicTest
    {
        private IFimaEmailService _emailservice;
        private IScanLogic _scanlogic;
        private Mock<IFimaRepo> fimarepoMock;

        [SetUp]
        public void Setup()
        {
            fimarepoMock = new Mock<IFimaRepo>();
            _emailservice = new FimaEmailService();
            _scanlogic = new ScanLogic(fimarepoMock.Object,_emailservice);
        }

        [Test]
        public void TestScanShopDbForEmailSend()
        {
            // Arrange
            var uid = Guid.NewGuid().ToString();
            fimarepoMock.Setup(x => x.GetFilterIdsFromShop(It.IsAny<string>()))
                .Returns(new List<int>());
            fimarepoMock.Setup(x => x.GetProducts())
                .Returns(new List<Product>());

            var user = new FimaUser{
                UserName = "Test tony1",
                Email = "test.tony1@gmail.com",
                Id = uid,
                SendEmailToSeller = true,
                SendNotificationEmailToUser = true,
            };
            var tags ="1;2;3";
            var price = 1200;

            // Act
            _scanlogic.ScanShopDbForEmailSend(user,tags,price);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void TestScanShopDbForEmailSendWithHigherPrice()
        {
            // Arrange
            var uid = Guid.NewGuid().ToString();
            fimarepoMock.Setup(x => x.GetFilterIdsFromShop(It.IsAny<string>()))
                .Returns(new List<int>());
            fimarepoMock.Setup(x => x.GetProducts())
                .Returns(new List<Product> 
                { new Product 
                { ProductPrice = 1500, ProductName = "Test tech", ProductTags = "1;2;3", ProductId = 2 } });

            var user = new FimaUser
            {
                UserName = "Test tony2",
                Email = "test.tony2@gmail.com",
                Id = uid,
                SendEmailToSeller = true,
                SendNotificationEmailToUser = true,
            };
            var tags = "1;2;3";
            var price = 1200;

            // Act
            _scanlogic.ScanShopDbForEmailSend(user, tags, price);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void TestScanShopDbForEmailSendWithoutNotification()
        {
            // Arrange
            var uid = Guid.NewGuid().ToString();
            fimarepoMock.Setup(x => x.GetFilterIdsFromShop(It.IsAny<string>()))
                .Returns(new List<int> {1,2,3});
            fimarepoMock.Setup(x => x.GetProducts())
                .Returns(new List<Product>
                { new Product
                { ProductPrice = 1000, ProductName = "Test Telescope", ProductTags = "4;5;6", ProductId = 3 } });

            var user = new FimaUser
            {
                UserName = "Test tony2",
                Email = "test.tony2@gmail.com",
                Id = uid,
                SendEmailToSeller = false,
                SendNotificationEmailToUser = false,
            };
            var tags = "4;5;6";
            var price = 1200;

            // Act
            _scanlogic.ScanShopDbForEmailSend(user, tags, price);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void TestScanDbForAllFilters()
        {
            // Arrange
            var uid = Guid.NewGuid().ToString();
            fimarepoMock.Setup(x => x.GetFilterIdsFromShop(It.IsAny<string>()))
                .Returns(new List<int>());
            fimarepoMock.Setup(x => x.GetProducts())
                .Returns(new List<Product>
                { new Product
                { ProductPrice = 2000, ProductName = "Test Table", ProductTags = "7;8;9", ProductId = 5 } });

            var user = new FimaUser
            {
                UserName = "Test tony3",
                Email = "test.tony3@gmail.com",
                Id = uid,
                SendEmailToSeller = false,
                SendNotificationEmailToUser = false,
            };

            // Act
            _scanlogic.ScanDbForAllFilters();

            // Assert
            Assert.Pass();
        }

        [Test]
        public void TestNotifySeller()
        {
            // Arrange
            var uid = Guid.NewGuid().ToString();
            var p = new Product() { ProductName = "Test transistor", ProductTags="10;154;200", ProductPrice = 1000, ProductId = 5, ProductSellerEmail= "Testseller@gmail.com" };

            fimarepoMock.Setup(x => x.GetFilterIdsFromShop(It.IsAny<string>()))
                .Returns(new List<int>());
            fimarepoMock.Setup(x => x.GetProducts())
                .Returns(new List<Product>
                { p });

            var user = new FimaUser
            {
                UserName = "Test tony4",
                Email = "test.tony5@gmail.com",
                Id = uid,
                SendEmailToSeller = true,
                SendNotificationEmailToUser = true,
                EmailText = "Dear seller, i am very interested in your product! Contact me at: ineedyourproduct@gmail.com"
            };

            // Act
            _scanlogic.NotifySeller(user, p);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void TestNotifySellerWithFalseNotifyProperty()
        {
            // Arrange
            var uid = Guid.NewGuid().ToString();
            var p = new Product() { ProductName = "Test tesseract", ProductTags = "13;16;300", ProductPrice = 99999, ProductId = 1, ProductSellerEmail = "Testseller2@gmail.com" };

            fimarepoMock.Setup(x => x.GetFilterIdsFromShop(It.IsAny<string>()))
                .Returns(new List<int>() { 1, 2 });
            fimarepoMock.Setup(x => x.GetProducts())
                .Returns(new List<Product>
                { p });

            var user = new FimaUser
            {
                UserName = "Test tony5",
                Email = "test.tony5@gmail.com",
                Id = uid,
                SendEmailToSeller = false,
                SendNotificationEmailToUser = true,
                EmailText = "Dear seller, i am very interested in your product! Contact me at: ineedyourproduct@gmail.com"
            };

            // Act
            _scanlogic.NotifySeller(user, p);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void TestNotifySellerWithEmptyEmailBody()
        {
            // Arrange
            var uid = Guid.NewGuid().ToString();
            var p = new Product() { ProductName = "Test tv", ProductTags = "76;54;247", ProductPrice = 35000, ProductId = 23, ProductSellerEmail = "Testseller3@gmail.com" };

            fimarepoMock.Setup(x => x.GetFilterIdsFromShop(It.IsAny<string>()))
                .Returns(new List<int>() { 1, 2 });
            fimarepoMock.Setup(x => x.GetProducts())
                .Returns(new List<Product>
                { p });

            var user = new FimaUser
            {
                UserName = "Test tony6",
                Email = "test.tony6@gmail.com",
                Id = uid,
                SendEmailToSeller = false,
                SendNotificationEmailToUser = true,
                EmailText = null
            };

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => _scanlogic.NotifySeller(user,p));
        }
    }
}

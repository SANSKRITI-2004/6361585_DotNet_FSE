using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerCommLib.CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            // Arrange: Create mock object
            _mockMailSender = new Mock<IMailSender>();

            // Setup mock to return true for any strings passed
            _mockMailSender
                .Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            // Inject mock into CustomerComm
            _customerComm = new CustomerCommLib.CustomerComm(_mockMailSender.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMocked()
        {
            // Act
            var result = _customerComm.SendMailToCustomer();

            // Assert
            Assert.That(result, Is.True);

            // Optionally verify that SendMail was called once
            _mockMailSender.Verify(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}

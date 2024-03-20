using System.Net.Mail;
using System.Net;

namespace FimaService.FimaEmailService
{
    public interface IFimaEmailService
    {
        public void SendEmail(string userEmail, string emailSubject, string messageBody);

        public void SendEmailToUser(string userEmail, string filterName, string linkToProduct);

        public void SendEmailToSeller(string emailText, string sellerEmail, string productName);

    }
}
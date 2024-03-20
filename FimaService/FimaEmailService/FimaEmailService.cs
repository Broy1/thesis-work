using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FimaService.FimaEmailService
{
    public class FimaEmailService : IFimaEmailService
    {
        public void SendEmail(string userEmail, string emailSubject, string messageBody)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                throw new ArgumentNullException("userEmail");
            }
            if (string.IsNullOrEmpty(messageBody))
            {
                throw new ArgumentNullException("messageBody");
            }

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("fima.jarvis@gmail.com");
            msg.IsBodyHtml = true;
            msg.To.Add($"{userEmail}");
            msg.Subject = $"{emailSubject}";
            msg.Body = $"{messageBody}";

            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("fima.jarvis@gmail.com", "");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }
        }
        public void SendEmailToUser(string userEmail,string filterName, string linkToProduct)
        {
            string emailSubject = "We found an item of your liking!";
            string emailBody = $"<html><body><h4>Hi, this is Jarvis from Fima,</h4>Good news! {filterName} is available on the shop! <br> <a href={linkToProduct}>Check it out</a></body></html>";
            
            SendEmail(userEmail,emailSubject,emailBody);
        }

        public void SendEmailToSeller(string emailText, string sellerEmail, string productName)
        {
            string emailSubject = $"Someone is interested in the {productName} you are selling!";
            string emailBody = $"<html><body><h4>Hi, this is Jarvis from Fima,</h4>Good news! Someone is interested in an item you are selling! <br> This is their message for you:<br>\"{emailText}\"</a></body></html>";

            SendEmail(sellerEmail,emailSubject,emailBody);
        }
    }
}

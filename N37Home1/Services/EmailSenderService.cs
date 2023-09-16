using N37Home1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N37Home1.Services
{
    internal class EmailSenderService
    {
        public bool SendEmailsAsync(IEnumerable<EmailMessage> messages)
        {
            if (!messages.All(email => CheckEmailAddress(email.SenderAddress)))
                return false;

            foreach (var message in messages)
            {
                Task.Run(() =>
                {
                    try
                    {
                        SendEmail(message.ReceiverAddress);
                    }
                    catch
                    {
                        // filega shu email bilan muamo yoziladi
                    }
                    finally
                    {
                        // file.Close();
                    }
                });
            }
            Task.WaitAll();
            return true;
        }

        private bool CheckEmailAddress(string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
                return false;
                        
            if (Regex.IsMatch("^((?!\\.)[\\w\\-_.]*[^.])(@\\w+)(\\.\\w+(\\.\\w+)?[^.\\W])$", userEmail))
                return true;

            return false;
        }

        public bool SendEmail(string receiverAddress)
        {
            try // send message to UserEmail
            {
                var mail = new MailMessage("anvarjonovozodbek416@gmail.com", receiverAddress);
                mail.Subject = "Siz muvaffaqiyatli registratsiyadan o'tdingiz";
                mail.Body = "Hurmatli {{User FirstName}} {{User LastName}}, siz registratsiyadan muvaffaqiyatli o'tdingiz"
                    .Replace("{{User FirstName}}", "User")
                    .Replace("{{User LastName}}", "");
                var smtpClient = new SmtpClient("smtp.gmail.com", 587); // Replace with your SMTP server address and port
                smtpClient.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
                return true;
            }
            catch // for exeption
            {
                return false;
            }
        }
    }
}

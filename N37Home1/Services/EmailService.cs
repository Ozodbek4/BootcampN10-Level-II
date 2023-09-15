using N37Home1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37Home1.Services
{
    internal class EmailService
    {
        public IEnumerable<EmailMessage> GetMassages(IEnumerable<(User user, EmailTemplate temp, string senderEmail)> templates)
        {
            foreach(var template in templates)
            {
                yield return new EmailMessage(template.temp.Subject, template.temp.Body
                    .Replace("{{FirstName}}", $"{template.user.FirstName}")
                    .Replace("{{LastName}}", $"{template.user.LastName}"),
                    template.user.UserEmail, template.senderEmail);
            }
        }
    }
}

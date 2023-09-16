using N37Home1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37Home1.Services
{
    internal class EmailTemplateService
    {
        public IEnumerable<EmailTemplate> GetTemplates(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                if (user.Status == "Registered")
                    yield return new EmailTemplate("Hush kelibsiz",
                        $"Assalomu aleykum {user.FirstName} {user.LastName}, bizning saytimizga hush kelibsiz");
                else if (user.Status == "Deleted")
                    yield return new EmailTemplate("O'chirilgan account", 
                        $"Assalomu ayleykum {user.FirstName} {user.LastName}, uzrirasiz, sizni accountingiz o'chirilgan");
            }
        }
    }
}

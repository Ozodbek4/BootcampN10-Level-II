using N37Home1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37Home1.Services
{
    internal class NotificationManagementService
    {
        private readonly EmailSenderService _emailSenderService;
        private readonly EmailService _emailService;
        private readonly EmailTemplateService _emailTemplateService;
        private readonly UserService _userService;

        public NotificationManagementService(EmailSenderService emailSenderService, EmailService emailService, 
            EmailTemplateService emailTemplateService, UserService userService)
        {
            _emailSenderService = emailSenderService;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
            _userService = userService;
        }

        public void NotifyUsers()
        {
            var users = _userService.GetUser(new );
            var templates = _emailTemplateService.GetTemplates(users);
            var message = _emailService.GetMassages(IEnumerable<(User, EmailTemplate, string)>x(users, templates, "anvarjonovozodbek416@gmail.com"));
        }
    }
}

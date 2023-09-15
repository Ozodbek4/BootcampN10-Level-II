using N37Home1.Services;

var users = _userService.GetUsers();
var templates = _emailTemplateService.GetTemplates(users);
var messages = _emailService.GetMessages(templates, users);
await _emailSenderService.SendEmailsAsync(messages);
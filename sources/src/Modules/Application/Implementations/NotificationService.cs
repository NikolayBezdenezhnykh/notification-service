using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Dtos;
using Infrastructure.EmailSender;
using Infrastructure.MessageTemplateProvider;

namespace Application.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IMessageTemplateProvider _messageTemplateProvider;
        private readonly IEmailSender _emailSender;

        public NotificationService(
            IMessageTemplateProvider messageTemplateProvider,
            IEmailSender emailSender)
        {
            _messageTemplateProvider = messageTemplateProvider;
            _emailSender = emailSender;
        }

        public async Task SendEmailAsync(EmailNotificationDto emailNotificationDto)
        {
            var template = await _messageTemplateProvider.GetMessageTemplateAsync(emailNotificationDto.Template);
            foreach (var param in emailNotificationDto.DynamicParams)
            {
                template.Content = template.Content.Replace(param.Key, param.Value);
            }

            await _emailSender.SendEmailAsync(emailNotificationDto.EmailTo, template.From, template.Subject, template.Content);
        }
    }
}

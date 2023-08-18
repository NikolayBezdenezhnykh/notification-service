using Application.Dtos;
using Application.Interface;
using Infrastructure.KafkaConsumerHandlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations
{
    public class KafkaMessageNotifyHandler : IKafkaMessageHandler
    {
        private readonly INotificationService _notificationService;

        public KafkaMessageNotifyHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task HandleMessageAsync(string message)
        {
            await _notificationService.SendEmailAsync(JsonConvert.DeserializeObject<EmailNotificationDto>(message));
        }
    }
}

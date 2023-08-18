using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageTemplateProvider
{
    public interface IMessageTemplateProvider
    {
        Task<MessageTemplate> GetMessageTemplateAsync(string messageTemplateCode);
    }
}

using Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageTemplateProvider
{
    public class MessageTemplateProvider : IMessageTemplateProvider
    {
        private const string _dataBase = "notification-service";
        private const string _collectionName = "MessageTemplate";

        private readonly MongoClient _mongoClient;

        public MessageTemplateProvider(MongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<MessageTemplate> GetMessageTemplateAsync(string messageTemplateCode)
        {
            var db = _mongoClient.GetDatabase(_dataBase);
            var collection = db.GetCollection<MessageTemplate>(_collectionName);

            var filter = Builders<MessageTemplate>.Filter.Eq(r => r.TemplateCode, messageTemplateCode);

            var template = await collection.Find(filter).FirstOrDefaultAsync();

            return template;
        }
    }
}

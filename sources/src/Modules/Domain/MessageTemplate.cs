using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MessageTemplate
    {
        public ObjectId Id { get; set; }

        public string TemplateCode { get; set; }

        public string Subject { get; set; }

        public string From { get; set; }

        public string Content { get; set; }

    }
}

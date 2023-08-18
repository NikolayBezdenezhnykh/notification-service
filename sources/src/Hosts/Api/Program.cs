using Application.Implementations;
using Application.Interface;
using Infrastructure.EmailSender;
using Infrastructure.KafkaConsumerHandlers;
using Infrastructure.MessageTemplateProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using MongoDB.Driver;
using Microsoft.Extensions.Hosting;

namespace notification_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetSection("MONGODBURI").Value;
            builder.Services.AddSingleton(new MongoClient(connectionString));
            builder.Services.AddSingleton<INotificationService, NotificationService>();
            builder.Services.AddSingleton<IEmailSender, EmailSender>();
            builder.Services.AddSingleton<IMessageTemplateProvider, MessageTemplateProvider>();
            builder.Services.AddSingleton<KafkaMessageNotifyHandler>();
            builder.Services.AddSingleton<IKafkaMessageHandlerFactory, KafkaMessageHandlerFactory>();
            builder.Services.AddHostedService<KafkaConsumerHandler>();
            builder.Services.Configure<KafkaConsumerConfig>(options => builder.Configuration.GetSection("KafkaConsumer").Bind(options));

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
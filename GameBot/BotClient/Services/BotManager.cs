using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BotClient.Services
{
    public class BotManager
    {
        private IHost host;
        public static string Connection;
        public BotManager()
        {
            Initialization("", true);
        }
        public BotManager(string token)
        {
            Initialization(token, false);
        }
        private void Initialization(string token, bool isdefault)
        {
            host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   // Register Bot configuration
                   services.Configure<BotConfiguration>(
                       context.Configuration.GetSection(BotConfiguration.Configuration));

                   // Register named HttpClient to benefits from IHttpClientFactory
                   // and consume it with ITelegramBotClient typed client.
                   services.AddHttpClient("telegram_bot_client")
                           .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                           {
                               BotConfiguration? botConfig = sp.GetConfiguration<BotConfiguration>();
                               if (!isdefault) botConfig.BotToken = token;
                               TelegramBotClientOptions options = new(botConfig.BotToken);
                               return new TelegramBotClient(options, httpClient);
                           });

                   services.AddScoped<UpdateHandler>();
                   services.AddScoped<ReceiverService>();
                   services.AddHostedService<PollingService>();
               })
               .Build();
        }
        public async void Start(string connection)
        {
            Connection = connection;
            await host.StartAsync();
        }
        public async void Stop()
        {
            await host.StopAsync();
        }

    }
    public class BotConfiguration
    {
        public static readonly string Configuration = "BotConfiguration";

        public string BotToken { get; set; } = "5921385779:AAEBFzLyOjmL2TJ1eQ4tsGu79B0Hn4d4mKA";
    }
}

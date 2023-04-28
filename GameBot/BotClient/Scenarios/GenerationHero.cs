using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using GeneralLibrary.BaseModels;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    public class GenerationHero: BaseScenario
    {
        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {

            return await base.Start(botClient, message, cancellationToken, user);
        }
    }
}

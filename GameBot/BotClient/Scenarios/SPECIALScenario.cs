using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotClient.Scenarios
{
    internal class SPECIALScenario:BaseScenario
    {
        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, GeneralLibrary.BaseModels.User user)
        {
            Task<Message> response = null;
            return await response;
        }
    }
}

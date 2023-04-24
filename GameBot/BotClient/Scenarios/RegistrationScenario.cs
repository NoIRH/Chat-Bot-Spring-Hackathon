using BotClient.Scenarios;
using Controllers.Controllers;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Controllers.Scenarios
{
    internal class RegistrationScenario : BaseScenario
    {
        private GameController _gameController;

        public GameController Controller
        {
            set => _gameController = value;
        }

        public async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var user = new GeneralLibrary.BaseModels.User() { Id = (int)message.From.Id, ChatId = (int)message.Chat.Id };

            
            return null;
        }
    }
}

using BotClient.Scenarios;
using Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Controllers.Scenarios
{
    internal class RegistrationScenario: BaseScenario
    {
        private GameController _gameController;

        public GameController Controller
        {
            set => _gameController = value;
        }

        public async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {

        }
    }
}

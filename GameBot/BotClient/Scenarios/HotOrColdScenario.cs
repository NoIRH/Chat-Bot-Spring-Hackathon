using Controllers.Controllers;
using Controllers.Scenarios;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    internal class HotOrColdScenario : BaseScenario
    {
        public GameController GameController { get; set; }
        
        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            if (user.CurrentScenarioStep == 0)
            {
                GameController.StartHotOrCold(user);
                user.CurrentScenarioStep += 1;
                await SendMessage(botClient, message, cancellationToken, user.GameContext.MiniGame.GameDescription);
                return await SendMessage(botClient, message, cancellationToken, "Загадайте число");
            }
            else if (user.CurrentScenarioStep == 1)
            {
                var answer = GameController.HotOrColdNext(user, Convert.ToInt32(message.Text));
                if (!user.GameContext.MiniGame.IsWorked)
                    user.CurrentScenarioStep += 1;
                return await SendMessage(botClient, message,cancellationToken, answer);
            }
            else
            {
                return await new StartScenario { Controller = Controller }.Start(botClient, message, cancellationToken, user, StartScenario.Options.Menu);
            }
        }
    }
}

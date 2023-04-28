using Controllers.Scenarios;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    public class GeneralScenario : BaseScenario
    {
        public async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            Task<Message> scenario;

            if (user.ScenarioId == (int)TypeScenario.Start)
            {
                scenario = new StartScenario { Controller = Controller}.Start(botClient, message, cancellationToken, user);
            }
            else if (user.ScenarioId == (int)TypeScenario.Registration)
            {
                scenario = new RegistrationScenario { Controller = Controller}.Start(botClient, message, cancellationToken, user);
            }
            else if (user.ScenarioId == (int)TypeScenario.GenerationHero)
            {
                scenario = new GeneralScenario { Controller = Controller }.Start(botClient, message, cancellationToken, user);
            }
            else
            {
                scenario = GetHelp(botClient, message, cancellationToken);
            }
            return await scenario;
        }
    }
}

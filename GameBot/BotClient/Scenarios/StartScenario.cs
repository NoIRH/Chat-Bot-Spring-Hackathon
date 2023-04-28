using BotClient.Scenarios;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = GeneralLibrary.BaseModels.User;

namespace Controllers.Scenarios
{
    public class StartScenario : BaseScenario
    {
        public async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            Task<Message> answer;
            StartTyping(botClient, message, cancellationToken);
            if (user == null)
            {
                var textOfGreeting = "Добро пожаловать!\nВам обязательно нужно зарегистрироваться!";
                await SendMessage(botClient, message, cancellationToken, textOfGreeting);
                answer = new RegistrationScenario { Controller = Controller }.Start(botClient, message, cancellationToken, user);
            }
            else
            {
                //user.ScenarioId = 
                answer = SendMessage(botClient, message, cancellationToken, $"Добро Пожаловать! {user.Name}!");
            }
            return await answer;
        }
    }
}

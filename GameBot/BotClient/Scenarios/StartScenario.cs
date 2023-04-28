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
            Task<Message> answer = null;
            StartTyping(botClient, message, cancellationToken);
            if (user == null)
            {
                var textOfGreeting = "Добро пожаловать!\nВам обязательно нужно зарегистрироваться!";
                await SendMessage(botClient, message, cancellationToken, textOfGreeting);
                answer = new RegistrationScenario { Controller = Controller }.Start(botClient, message, cancellationToken, user);
                return await answer;
            }
            if (user.CurrentScenarioStep == 0)
            {
                user.ScenarioId = (int)TypeScenario.Start;
                user.CurrentScenarioStep += 1;
                answer = SendMessage(botClient, message, cancellationToken, $"Добро Пожаловать! {user.Name}!");
            }
            else if (user.CurrentScenarioStep == 1)
            {
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Статистика", "1"),
                        InlineKeyboardButton.WithCallbackData("Отправиться в данж", "0"),
                        InlineKeyboardButton.WithCallbackData("Вступить в бой", "0"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Мини-игры", "1"),
                        InlineKeyboardButton.WithCallbackData("Таблица рекордов", "0")
                    }
               });
                user.CurrentScenarioStep += 1;
                answer = SendMessage(botClient, message, cancellationToken, "", inlineKeyboard);
            }
            else if (user.CurrentScenarioStep == 2)
            {
                
            }
            return await answer;
        }
    }
}

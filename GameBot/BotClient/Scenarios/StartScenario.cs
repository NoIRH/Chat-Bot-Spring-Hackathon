using BotClient.Scenarios;
using Controllers.Controllers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Controllers.Scenarios
{
    public class StartScenario : BaseScenario
    {
        public GameController Controller { private get; set; }

        public async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            Task<Message> answer;
            StartTyping(botClient, message, cancellationToken);
            var currentUser = Controller.GetUser((int)message.From.Id);
            InlineKeyboardMarkup inlineKeyboard = new(
                new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Да", "1"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Нет", "0"),
                    }
                });
            if (currentUser == null)
            {
                var textOfGreeting = "Добро пожаловать!\nПерейдём к регистрации?";
                answer = SendMessage(botClient, message, cancellationToken, textOfGreeting, inlineKeyboard);
                new RegistrationScenario { Controller = Controller }.Start(botClient, message, cancellationToken);
            }
            else
            {
                answer = SendMessage(botClient, message, cancellationToken, "Добро Пожаловать!");
                GetHelp(botClient, message, cancellationToken);
            }
            return await answer;
        }
    }
}

using BotClient.Scenarios;
using Controllers.Controllers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Controllers.Scenarios
{
    public class StartScenario : BaseScenario
    {
        private GameController _gameController;

        public GameController Controller 
        { 
            set => _gameController = value;
        }

        public async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            Task<Message> answer = null;
            var currentUser = _gameController.GetUser((int)message.From.Id);
            if (currentUser == null)
            {
                var textOfGreeting = "Добро пожаловать!\nПерейдём к регистрации?";
                answer = SendMessage(botClient, message, cancellationToken, textOfGreeting);
                 //new RegistrationScenario { Controller = _gameController }.Start(botClient, message, cancellationToken);
            }
            else
            {
                answer =  SendMessage(botClient, message, cancellationToken, "Добро Пожаловать!");
            }
            InlineKeyboardMarkup inlineKeyboard = new(
                new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Да", "AWD"),
                    }
                });

            return await answer;
        }

        private static async Task<Message> SendMessage(ITelegramBotClient botClient, Message message, 
            CancellationToken cancellationToken, string text)=> await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Добро пожаловать!\n" +
                    "Перейдём к регистрации?",
                cancellationToken: cancellationToken);
    }
}

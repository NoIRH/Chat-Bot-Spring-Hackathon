using BotClient.Scenarios;
using Controllers.Controllers;
using Telegram.Bot.Types;
using Telegram.Bot;
using User = GeneralLibrary.BaseModels.User;
using Telegram.Bot.Types.ReplyMarkups;

namespace Controllers.Scenarios
{
    internal class RegistrationScenario : BaseScenario
    {
        private BaseController _baseController;

        public BaseController Controller
        {
            set => _baseController = value;
        }

        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            Task<Message> action = null;
            if (user == null)
            {
                user = new User() { Id = (int)message.From.Id, ChatId = (int)message.Chat.Id, ScenarioId = (int)TypeScenario.Registration };
            }

            if (user.CurrentScenarioStep == 0)
            {
                var text = "⟱ Введите, пожалуйста, имя ⟱";
                action = SendMessage(botClient, message, cancellationToken, text);
                user.CurrentScenarioStep += 1;
            }

            else if (user.CurrentScenarioStep == 1)
            {
                var text = "⟱ Вы уверены? ⟱";
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Да", "1"),
                        InlineKeyboardButton.WithCallbackData("Нет", "0"),
                    }
               });
                user.CurrentScenarioStep += 1;
                action = SendMessage(botClient, message, cancellationToken, text, inlineKeyboard);
            }

            else if (user.CurrentScenarioStep == 2)
            {

            }

            return await action;
        }
    }
}

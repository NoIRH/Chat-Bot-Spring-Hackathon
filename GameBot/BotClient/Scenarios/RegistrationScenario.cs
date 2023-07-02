using BotClient.Scenarios;
using Telegram.Bot.Types;
using Telegram.Bot;
using User = GeneralLibrary.BaseModels.User;
using Telegram.Bot.Types.ReplyMarkups;

namespace Controllers.Scenarios
{
    internal class RegistrationScenario : BaseScenario
    {
        public override void Solve(User user, CallbackQuery callbackQuery)
        {
            var step = user.CurrentScenarioStep;
            var answer = Convert.ToBoolean(callbackQuery.Data.Split("_")[0]);
            user.CurrentScenarioStep = answer ? user.CurrentScenarioStep += 1 : user.CurrentScenarioStep -= 1;
        }

        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            if (user == null)
            {
                user = new User()
                {
                    Id = (int)message.From.Id,
                    ChatId = (int)message.Chat.Id,
                    Name = $"NoName#{message.From.Id}",
                    ScenarioId = (int)TypeScenario.Registration,
                };
                Controller.AddUser(user);
                var text = "Итак, давайте начнём регистрацию!";
                await SendMessage(botClient, message, cancellationToken, text);
            }
            // steps of registration scenario.
            if (user.CurrentScenarioStep == 0)
            {
                var text = "⟱ Введите, пожалуйста, имя ⟱";
                user.CurrentScenarioStep += 1;
                return await SendMessage(botClient, message, cancellationToken, text);
            }
            else if (user.CurrentScenarioStep == 1)
            {
                var text = "⟱ Вы уверены? ⟱";
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Да", "true"),
                        InlineKeyboardButton.WithCallbackData("Нет", "false")
                    }
               });
                user.Name = message.Text;
                Controller.UpdateDataDB();
                return await SendMessage(botClient, message, cancellationToken, text, inlineKeyboard);
            }
            else if (user.CurrentScenarioStep == 2)
            {
                var text = "⟱ Пожалуйста, выбирите отдел ⟱";
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("1", "true_1"),
                        InlineKeyboardButton.WithCallbackData("2", "true_2"),
                    }
               });
                return await SendMessage(botClient, message, cancellationToken, text, inlineKeyboard);
            }
            else if (user.CurrentScenarioStep == 3)
            {
                var text = "⟱ Вы уверены? ⟱";
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Да", "true"),
                        InlineKeyboardButton.WithCallbackData("Нет", "false")
                    }
               });
                user.Department = message.Text.Split("_")[1];
                Controller.UpdateDataDB();
                return await SendMessage(botClient, message, cancellationToken, text, inlineKeyboard);
            }
            else
            {
                user.ScenarioId = (int)TypeScenario.Start;
                user.CurrentScenarioStep = (int)StartScenario.Options.Greeting;
                Controller.UpdateDataDB();
                return await new StartScenario() { Controller = Controller }.Start(botClient, message, cancellationToken, user); // if this throw exception, then everything is ok.
            }
        }
    }
}

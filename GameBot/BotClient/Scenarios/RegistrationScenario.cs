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
                user = new User()
                {
                    Id = (int)message.From.Id,
                    ChatId = (int)message.Chat.Id,
                    Name = $"User#{message.From.Id}",
                    ScenarioId = (int)TypeScenario.Registration,
                    ClanId = -1,
                    Clan = new GeneralLibrary.BaseModels.Clan() { Id = -1, Name = "" },
                    Role = new GeneralLibrary.BaseModels.Role()
                    {
                        Id = -1,
                        Name = "",
                        Type = GeneralLibrary.BaseModels.TypeRole.User
                    },
                    Department = ""
                };
                _baseController.AddUser(user);
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
                if (true)
                {
                    user.CurrentScenarioStep += 1;
                }
                else
                {
                    user.CurrentScenarioStep = 0;
                }
            }
            else if (user.CurrentScenarioStep == 3)
            {
                var text = "⟱ Пожалуйста, выбирите отдел ⟱";
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("1", "1"),
                        InlineKeyboardButton.WithCallbackData("2", "2"),
                    }
               });
                user.CurrentScenarioStep += 1;
                action = SendMessage(botClient, message, cancellationToken, text, inlineKeyboard);
            }
            else if (user.CurrentScenarioStep == 4)
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
            else if (user.CurrentScenarioStep == 5)
            {
                var text = "⟱ Готовы создать свою черепашку? ⟱";
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
            else if (user.CurrentScenarioStep == 6)
            {
                user.ScenarioId = (int)TypeScenario.GenerationHero;
                user.CurrentScenarioStep = 0;
                action = new GenerationHero() { Controller = _baseController }.Start(botClient, message, cancellationToken, user);
            }

            return await action;
        }
    }
}

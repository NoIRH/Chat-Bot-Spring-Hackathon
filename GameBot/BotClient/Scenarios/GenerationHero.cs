using GameEngine.GameModels.Characters;
using GameEngine.GameModels.CharDescription;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    public class GenerationHero : BaseScenario
    {
        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            if (user.Hero == null)
            {
                user.Hero = new Hero()
                {
                    Name = "Черепашка" + user.Name,
                    CountMoney = 100,
                    PowerPoints = 1,
                    Expirience = 1
                };
                user.Hero.Inventory = new Inventory();
                Controller.UpdateDataDB();
                var text = "Итак, давайте начнём создание своей черепашкаи!";
                await SendMessage(botClient, message, cancellationToken, text);
            }
            if (user.CurrentScenarioStep == 0)
            {
                var text = "⟱ Введите, пожалуйста, имя своей черепашки ⟱";
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
                user.Hero.Name = message.Text;
                Controller.UpdateDataDB();
                return await SendMessage(botClient, message, cancellationToken, text, inlineKeyboard);
            }
            else if (user.CurrentScenarioStep == 2)
            {
                var text = "⟱ Пожалуйста, выбирите класс ⟱";
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Воин", "true_Воин"),
                        InlineKeyboardButton.WithCallbackData("Маг", "true_Маг"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Плут", "true_Плут"),
                        InlineKeyboardButton.WithCallbackData("Паладин", "true_Паладин"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Берсерк", "true_Берсерк"),
                        InlineKeyboardButton.WithCallbackData("Бард", "true_Бард"),
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
                user.Hero.Class = new CharacterClass() { Name = message.Text };
                Controller.UpdateDataDB();
                return await SendMessage(botClient, message, cancellationToken, text, inlineKeyboard);
            }
            else
            {
                var text = "Создание героя почти окончено!\nещё нужно распределить очки навыков!";
                await SendMessage(botClient, message, cancellationToken, text);
                user.ScenarioId = (int)TypeScenario.SPECIAL;
                user.CurrentScenarioStep = 0;
                Controller.UpdateDataDB();
                return await new SPECIALScenario().Start(botClient, message, cancellationToken, user); // if this throw exception, then everything is ok.
            }
        }

        public override void Solve(User user, CallbackQuery callbackQuery)
        {
            var answer = callbackQuery.Data.Split("_");
            if (answer.Length == 2)
            {
                callbackQuery.Data = answer[1];
            }
            if (Convert.ToBoolean(answer[0]))
            {
                user.CurrentScenarioStep += 1;
            }
            else
            {
                user.CurrentScenarioStep -= 1;
            }
        }
    }
}

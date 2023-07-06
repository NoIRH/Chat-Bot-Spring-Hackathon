using Controllers.Controllers;
using Controllers.Scenarios;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    internal class CalculationGameScenario : BaseScenario
    {
        public GameController GameController { get; set; }

        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            if (user.CurrentScenarioStep == 0)
            {
                GameController.StartCalculationGame(user);
                user.CurrentScenarioStep += 1;
                return await SendMessage(botClient, message, cancellationToken, user.GameContext.MiniGame.GameDescription);
            }
            else if (user.CurrentScenarioStep == 1)
            {
                var data = GameController.CalculationGameNext(user);
                var example = data.example;
                var varinats = data.variants;
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData($"{varinats[0]}", $"{varinats[0]}")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData($"{varinats[1]}", $"{varinats[0]}")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData($"{varinats[2]}", $"{varinats[0]}")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData($"{varinats[3]}", $"{varinats[0]}")
                    }
               });
                if (!user.GameContext.MiniGame.IsWorked)
                    user.CurrentScenarioStep += 1;
                return await SendMessage(botClient, message, cancellationToken, example, inlineKeyboard);
            }
            else
            {
                await SendMessage(botClient, message, cancellationToken, GameController.GetCalculationGameStatistic(user));
                user.CurrentScenarioStep = 0;
                return await new StartScenario { Controller = Controller }.Start(botClient, message, cancellationToken, user, StartScenario.Options.Menu);
            }
        }
        public override void Solve(User user, CallbackQuery callbackQuery)
        {
            var item = Convert.ToDouble(callbackQuery.Data);
            GameController.WriteAnswer(user, item);
        }
    }
}

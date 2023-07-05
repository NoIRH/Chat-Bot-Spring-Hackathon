using BotClient.Scenarios;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = GeneralLibrary.BaseModels.User;

namespace Controllers.Scenarios
{
    public class StartScenario : BaseScenario
    {
        public enum Options
        {
            Greeting = 0,
            Menu = 1
        }

        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            //Print(botClient, message, cancellationToken);

            if (user == null)
            {
                var textOfGreeting = "Добро пожаловать!\nВам обязательно нужно зарегистрироваться!";
                await SendMessage(botClient, message, cancellationToken, textOfGreeting);
                return await new RegistrationScenario { Controller = Controller }.Start(botClient, message, cancellationToken, user);
            }

            if (user.Hero == null)
            {
                var textOfGreeting = "Пришло время создать свою черепашку :)";
                await SendMessage(botClient, message, cancellationToken, textOfGreeting);
                user.ScenarioId = (int)TypeScenario.GenerationHero;
                user.CurrentScenarioStep = 0;
                return await new GenerationHero { Controller = Controller }.Start(botClient, message, cancellationToken, user);
            }

            if (user.CurrentScenarioStep == 0)
            {
                user.CurrentScenarioStep += 1;
                Controller.UpdateDataDB();
                await SendMessage(botClient, message, cancellationToken, $"Добро Пожаловать {user.Name}!");
            }
            if (user.CurrentScenarioStep == 1)
            {
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Статистика", "0"),
                        InlineKeyboardButton.WithCallbackData("Таблица рекордов", "1"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Отправиться в данж", "2"),
                        InlineKeyboardButton.WithCallbackData("Вступить в бой", "3"),
                        InlineKeyboardButton.WithCallbackData("Мини-игры", "4"),
                    }
               });
                return await SendMessage(botClient, message, cancellationToken, "Меню", inlineKeyboard);
            }
            else
            {
                var answer = Convert.ToInt32(message.Text);
                return answer switch
                {
                    1 => null,
                    2 => null,
                    3 => null,
                    4 => null,
                    _ => null
                };
            }
        }

        public async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user, Options optionScenario)
        {
            if (user != null)
                user.CurrentScenarioStep = (int)optionScenario;
            return await Start(botClient, message, cancellationToken, user);
        }

        public override void Solve(User user, CallbackQuery callbackQuery)
        {
            var answer = Convert.ToInt32(callbackQuery.Data);
            user.CurrentScenarioStep += 1;
        }

        private void GetRates()
        {
            var rates = Controller.GetRates();
            if (rates == null)
            {

            }
            else
            {
                var messege = "Рейтинг\n";
                rates.Sort();
                for (int i = 0; i < rates.Count; i++)
                {
                    messege += rates[i].User.Name + rates[i].Mark + "\n";
                }
            }
        }
    }
}

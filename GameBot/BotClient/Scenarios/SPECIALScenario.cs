using Controllers.Scenarios;
using GameEngine.GameModels.CharDescription;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    internal class SPECIALScenario : BaseScenario
    {
        private enum Description
        {
            S = 0,
            P = 1,
            E = 2,
            C = 4,
            I = 8,
            A = 16,
            L = 32,
            Add = 128,
            Dec = 256,
            OK = 512,
            Cancel = 1024
        }

        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            if (user.Hero.StatusBase == null)
            {
                user.Hero.StatusBase = new Status() { Strength = 5, Perception = 5, Endurance = 5, Charisma = 5, Intelligence = 5, Agility = 5, Luck = 5 };
                var text = "Итак, давайте начнём распределение очков!";
                await SendMessage(botClient, message, cancellationToken, text);
            }

            if (user.CurrentScenarioStep == 0)
            {
                InlineKeyboardMarkup inlineKeyboard = new(
                  new[]
                  {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("S", "1_5"),
                            InlineKeyboardButton.WithCallbackData("P", "2_5"),
                            InlineKeyboardButton.WithCallbackData("E", "4_5"),
                            InlineKeyboardButton.WithCallbackData("C", "8_5"),
                            InlineKeyboardButton.WithCallbackData("I", "16_5"),
                            InlineKeyboardButton.WithCallbackData("A", "32_5"),
                            InlineKeyboardButton.WithCallbackData("L", "64_5")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-", "128_5"),
                            InlineKeyboardButton.WithCallbackData("+", "256_5")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Подтвердить", "512")
                        }
                  });
                user.CurrentScenarioStep += 1;
                var status = user.Hero.StatusBase;
                return await SendMessage(botClient, message, cancellationToken,
                    $"Всего доступно {message.Text} очков\n" +
                    $"Strength (Сила — {status.Strength}\n" +
                    $"Perception (Восприятие)  — {status.Perception}\n" +
                    $"Endurance (Выносливость) — {status.Endurance}\n" +
                    $"Charisma (Харизма) — {status.Charisma}\n" +
                    $"Intelligence (Интеллект) — {status.Intelligence}\n" +
                    $"Agility (Ловкость) — {status.Agility}\n" +
                    $"Luck (Удача) — {status.Luck}", inlineKeyboard);
            }
            else if (user.CurrentScenarioStep == 1)
            {
                var score = message.Text.Split("_")[1];
                InlineKeyboardMarkup inlineKeyboard = new(
                  new[]
                  {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("S", $"0_{score}"),
                            InlineKeyboardButton.WithCallbackData("P", $"1_{score}"),
                            InlineKeyboardButton.WithCallbackData("E", $"2_{score}"),
                            InlineKeyboardButton.WithCallbackData("C", $"4_{score}"),
                            InlineKeyboardButton.WithCallbackData("I", $"8_{score}"),
                            InlineKeyboardButton.WithCallbackData("A", $"16_{score}"),
                            InlineKeyboardButton.WithCallbackData("L", $"32_{score}")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-", $"64_{score}"),
                            InlineKeyboardButton.WithCallbackData("+", $"128_{score}")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Подтвердить", "512")
                        }
                  });
                var status = user.Hero.StatusBase;
                return await EditMessageReplyMarkup(botClient, message, cancellationToken,
                    $"Всего доступно {score} очков\n" +
                    $"Strength (Сила — {status.Strength}\n" +
                    $"Perception (Восприятие)  — {status.Perception}\n" +
                    $"Endurance (Выносливость) — {status.Endurance}\n" +
                    $"Charisma (Харизма) — {status.Charisma}\n" +
                    $"Intelligence (Интеллект) — {status.Intelligence}\n" +
                    $"Agility (Ловкость) — {status.Agility}\n" +
                    $"Luck (Удача) — {status.Luck}", inlineKeyboard);
            }
            else if (user.CurrentScenarioStep == 2)
            {
                var text = "⟱ Вы уверены? ⟱";
                InlineKeyboardMarkup inlineKeyboard = new(
               new[]
               {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Да", "512_0"),
                        InlineKeyboardButton.WithCallbackData("Нет", "1024_0")
                    }
               });
                Controller.UpdateDataDB();
                return await SendMessage(botClient, message, cancellationToken, text, inlineKeyboard);
            }
            else
            {
                return await new StartScenario() { Controller = Controller }.Start(botClient, message, cancellationToken, user);
            }
        }

        public override void Solve(User user, CallbackQuery callbackQuery)
        {
            var data = callbackQuery.Data.Split("_");
            var score = Convert.ToInt32(data[1]);
            var item = Convert.ToInt32(data[0]);
            switch (item)
            {
                case (int)Description.S:
                    callbackQuery.Message.Text = Description.S.ToString() + score;
                    return;
                case (int)Description.P:
                    callbackQuery.Message.Text = Description.P.ToString() + score;
                    return;
                case (int)Description.E:
                    callbackQuery.Message.Text = Description.E.ToString() + score;
                    return;
                case (int)Description.C:
                    callbackQuery.Message.Text = Description.C.ToString() + score;
                    return;
                case (int)Description.I:
                    callbackQuery.Message.Text = Description.I.ToString() + score;
                    return;
                case (int)Description.A:
                    callbackQuery.Message.Text = Description.A.ToString() + score;
                    return;
                case (int)Description.L:
                    callbackQuery.Message.Text = Description.L.ToString() + score;
                    return;
                case (int)Description.Add:
                    score = Add(user.Hero.StatusBase, item, score);
                    callbackQuery.Message.Text = item.ToString() + score;
                    return;
                case (int)Description.Dec:
                    score = Decrease(user.Hero.StatusBase, item, score);
                    callbackQuery.Message.Text = item.ToString() + score;
                    return;
                case (int)Description.OK:
                    user.CurrentScenarioStep += 1;
                    break;
                case (int)Description.Cancel:
                    user.CurrentScenarioStep -= 1;
                    break;
            }
        }

        private int Add(Status status, int item, int score)
        {
            if (score == 5) return 5;
            switch (item)
            {
                case (int)Description.S:
                    status.Strength += 1;
                    break;
                case (int)Description.P:
                    status.Perception += 1;
                    break;
                case (int)Description.E:
                    status.Endurance += 1;
                    break;
                case (int)Description.C:
                    status.Charisma += 1;
                    break;
                case (int)Description.I:
                    status.Intelligence += 1;
                    break;
                case (int)Description.A:
                    status.Agility += 1;
                    break;
                case (int)Description.L:
                    status.Luck += 1;
                    break;
            }
            return score -= 1;
        }

        private int Decrease(Status status, int item, int score)
        {
            if (score == 0) return 0;
            switch (item)
            {
                case (int)Description.S:
                    status.Strength -= 1;
                    break;
                case (int)Description.P:
                    status.Perception -= 1;
                    break;
                case (int)Description.E:
                    status.Endurance -= 1;
                    break;
                case (int)Description.C:
                    status.Charisma -= 1;
                    break;
                case (int)Description.I:
                    status.Intelligence -= 1;
                    break;
                case (int)Description.A:
                    status.Agility -= 1;
                    break;
                case (int)Description.L:
                    status.Luck -= 1;
                    break;
            }
            return score += 1;
        }
    }
}

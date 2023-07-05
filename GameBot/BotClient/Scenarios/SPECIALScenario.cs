using Controllers.Scenarios;
using GameEngine.GameModels.CharDescription;
using Telegram.Bot;
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
            L = 32
        }

        private enum Operation
        {
            Change = 0,
            Dec = 1,
            Add = 2,
            OK = 4,
            Cancel = 8
        }

        public override async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            if (user.Hero.StatusBase == null)
            {
                user.Hero.StatusBase = new Status() { Strength = 5, Perception = 5, Endurance = 5, Charisma = 5, Intelligence = 5, Agility = 5, Luck = 5 };
                var text = "Итак, давайте начнём распределение очков!";
                Controller.UpdateDataDB();
                await SendMessage(botClient, message, cancellationToken, text);
            }

            if (user.CurrentScenarioStep == 0)
            {
                InlineKeyboardMarkup inlineKeyboard = new(
                  new[]
                  {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("S", "0_0_5"),
                            InlineKeyboardButton.WithCallbackData("P", "0_1_5"),
                            InlineKeyboardButton.WithCallbackData("E", "0_2_5"),
                            InlineKeyboardButton.WithCallbackData("C", "0_4_5"),
                            InlineKeyboardButton.WithCallbackData("I", "0_8_5"),
                            InlineKeyboardButton.WithCallbackData("A", "0_16_5"),
                            InlineKeyboardButton.WithCallbackData("L", "0_32_5")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-", "1_0_5"),
                            InlineKeyboardButton.WithCallbackData("+", "2_0_5")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Подтвердить", "4_0_0")
                        }
                  });
                user.CurrentScenarioStep += 1;
                message.Text = "5";
                var status = user.Hero.StatusBase;
                return await SendMessage(botClient, message, cancellationToken,
                    $"\tВсего доступно {message.Text} очков\n" +
                    $"\tStrength (Сила) — {status.Strength}\n" +
                    $"\tPerception (Восприятие)  — {status.Perception}\n" +
                    $"\tEndurance (Выносливость) — {status.Endurance}\n" +
                    $"\tCharisma (Харизма) — {status.Charisma}\n" +
                    $"\tIntelligence (Интеллект) — {status.Intelligence}\n" +
                    $"\tAgility (Ловкость) — {status.Agility}\n" +
                    $"\tLuck (Удача) — {status.Luck}", inlineKeyboard);
            }
            else if (user.CurrentScenarioStep == 1)
            {
                var data = message.Text.Split("_");
                var score = data[2];
                var item = data[1];
                InlineKeyboardMarkup inlineKeyboard = new(
                  new[]
                  {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("S", $"0_0_{score}"),
                            InlineKeyboardButton.WithCallbackData("P", $"0_1_{score}"),
                            InlineKeyboardButton.WithCallbackData("E", $"0_2_{score}"),
                            InlineKeyboardButton.WithCallbackData("C", $"0_4_{score}"),
                            InlineKeyboardButton.WithCallbackData("I", $"0_8_{score}"),
                            InlineKeyboardButton.WithCallbackData("A", $"0_16_{score}"),
                            InlineKeyboardButton.WithCallbackData("L", $"0_32_{score}")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-", $"1_{item}_{score}"),
                            InlineKeyboardButton.WithCallbackData("+", $"2_{item}_{score}")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Подтвердить", $"4_0_{score}")
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
                        InlineKeyboardButton.WithCallbackData("Да", "4_0_0"),
                        InlineKeyboardButton.WithCallbackData("Нет", "8_0_0")
                    }
               });
                Controller.UpdateDataDB();
                return await SendMessage(botClient, message, cancellationToken, text, inlineKeyboard);
            }
            else
            {
                user.ScenarioId = (int)TypeScenario.Start;
                user.CurrentScenarioStep = 0;
                return await new StartScenario() { Controller = Controller }.Start(botClient, message, cancellationToken, user);
            }
        }

        public override void Solve(User user, CallbackQuery callbackQuery)
        {
            var data = callbackQuery.Data.Split("_");
            var operation = Convert.ToInt32(data[0]);
            var item = Convert.ToInt32(data[1]);
            var score = Convert.ToInt32(data[2]);
            if (operation == (int)Operation.Change)
            {
                return;
            }
            else if (operation == (int)Operation.Add)
            {
                score = Add(user, item, score);
            }
            else if(operation == (int)Operation.Dec)
            {
                score = Decrease(user, item, score);
            }
            else if (operation == (int)Operation.OK)
            {
                user.CurrentScenarioStep += 1;
            }
            else if ((operation == (int)Operation.Cancel))
            {
                user.CurrentScenarioStep -= 1;
            }
            data[2] = score.ToString();
            callbackQuery.Data = string.Join("_", data);
        }

        private int Add(User user, int item, int score)
        {
            if (score == 0) return 0;
            var status = user.Hero.StatusBase;
            if (item == (int)Description.S)
            {
                status.Strength += 1;
            }
            else if (item == (int)Description.P)
            {
                status.Perception += 1;
            }
            else if (item == (int)Description.E)
            {
                status.Endurance += 1;
            }
            else if (item == (int)Description.C)
            {
                status.Charisma += 1;
            }
            else if (item == (int)Description.I)
            {
                status.Intelligence += 1;
            }
            else if (item == (int)Description.A)
            {
                status.Agility += 1;
            }
            else if (item == (int)Description.L)
            {
                status.Luck += 1;
            }
            return score - 1;
        }

        private int Decrease(User user, int item, int score)
        {
            if (score == 5) return 5;
            var status = user.Hero.StatusBase;
            if (item == (int)Description.S)
            {
                status.Strength -= 1;
            }
            else if (item == (int)Description.P)
            {
                status.Perception -= 1;
            }
            else if (item == (int)Description.E)
            {
                status.Endurance -= 1;
            }
            else if (item == (int)Description.C)
            {
                status.Charisma -= 1;
            }   
            else if (item == (int)Description.I)
            {
                status.Intelligence -= 1;
            }
            else if (item == (int)Description.A)
            {
                status.Agility -= 1;
            }
            else if (item == (int)Description.L)
            {
                status.Luck -= 1;
            }
            return score + 1;
        }
    }
}

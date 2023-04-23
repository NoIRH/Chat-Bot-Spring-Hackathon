using BotClient.Scenarios;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Controllers.Scenarios
{
    public class StartScenario : BaseScenario
    {
        public static async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            InlineKeyboardMarkup inlineKeyboard = new(
                new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Да", "AWD"),
                    }
                });

            return await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Добро пожаловать!\n" +
                    "Перейдём к регистрации?",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }
    }
}

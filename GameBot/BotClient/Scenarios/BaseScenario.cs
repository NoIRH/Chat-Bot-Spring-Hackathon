using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace BotClient.Scenarios
{
    public class BaseScenario
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        protected static async Task<Message> SendMessage(ITelegramBotClient botClient, Message message,
                CancellationToken cancellationToken, string text, IReplyMarkup replyMarkup = null) => await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Добро пожаловать!\n" +
                        "Перейдём к регистрации?",
                    replyMarkup: replyMarkup,
                    cancellationToken: cancellationToken);

        protected static async void StartTyping(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            await botClient.SendChatActionAsync(
                chatId: message.Chat.Id,
                chatAction: ChatAction.Typing,
                cancellationToken: cancellationToken);
        }

        protected static async void GetHelp(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            const string help = "Help:\n" +
                                 "/start - send inline keyboard\n" +
                                 "/keyboard    - send custom keyboard\n" +
                                 "/remove      - remove custom keyboard\n" +
                                 "/photo       - send a photo\n" +
                                 "/request     - request location or contact\n" +
                                 "/inline_mode - send keyboard with Inline Query";

            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: help,
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
        }
    }
}


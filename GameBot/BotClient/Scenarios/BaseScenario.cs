using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Controllers.Controllers;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    public class BaseScenario
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public GameController Controller { get;  set; }

        public virtual async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user) => null;

        //public async Task<Message> SendMessage(ITelegramBotClient botClient, Message message,
        //        CancellationToken cancellationToken, string textMessage) => await botClient.SendTextMessageAsync(
        //            chatId: message.Chat.Id,
        //            text: textMessage,
        //            cancellationToken: cancellationToken);

        public async Task<Message> SendMessage(ITelegramBotClient botClient, Message message,
                CancellationToken cancellationToken, string textMessage, IReplyMarkup replyMarkup = null) => await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: textMessage,
                    replyMarkup: replyMarkup,
                    cancellationToken: cancellationToken);

        public async void StartTyping(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            await botClient.SendChatActionAsync(
                chatId: message.Chat.Id,
                chatAction: ChatAction.Typing,
                cancellationToken: cancellationToken);
        }

        public async Task<Message> GetHelp(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            const string help = "Help:\n" +
                                 "/start       - send inline keyboard\n" +
                                 "/keyboard    - send custom keyboard\n" +
                                 "/remove      - remove custom keyboard\n" +
                                 "/photo       - send a photo\n" +
                                 "/request     - request location or contact\n" +
                                 "/inline_mode - send keyboard with Inline Query";

            return await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: help,
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
        }
    }
}


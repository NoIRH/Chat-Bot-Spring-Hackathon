using Controllers.Controllers;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    internal interface Scenario
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Controllers.Controllers.BaseController Controller { get; set; }

        public abstract Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user);

        public abstract Task<Message> SendMessage(ITelegramBotClient botClient, Message message,
                CancellationToken cancellationToken, string textMessage, IReplyMarkup replyMarkup);

        public abstract void Print(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken);

        public abstract Task<Message> PrintHelp(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken);

        public abstract void Solve(User user, CallbackQuery callbackQuery);

    }
}

using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using User = GeneralLibrary.BaseModels.User;
using System.Diagnostics.Contracts;

namespace BotClient.Scenarios
{
    public class BaseScenario
    {
        const string _help = "Help:\n" +
                                 "/start       - send inline keyboard\n" +
                                 "/keyboard    - send custom keyboard\n" +
                                 "/remove      - remove custom keyboard\n" +
                                 "/photo       - send a photo\n" +
                                 "/request     - request location or contact\n" +
                                 "/inline_mode - send keyboard with Inline Query";
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ScenariosController Controller { get;  set; }

        public virtual async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user) => null;

        public async Task<Message> SendMessage(ITelegramBotClient botClient, Message message,
                CancellationToken cancellationToken, string textMessage, IReplyMarkup replyMarkup = null) => await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: textMessage,
                    replyMarkup: replyMarkup,
                    cancellationToken: cancellationToken);

        public async void Print(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            await botClient.SendChatActionAsync(
                chatId: message.Chat.Id,
                chatAction: ChatAction.Typing,
                cancellationToken: cancellationToken);
        }

        public async Task<Message> PrintHelp(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            return await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: _help,
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
        }

        public virtual void Solve(User user, CallbackQuery callbackQuery)
        {
            var answer = Convert.ToBoolean(Convert.ToInt32(callbackQuery.Data));

            if (answer)
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


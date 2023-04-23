using BotClient.Scenarios;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using System.Threading;

namespace Controllers.Scenarios
{
    public class StartScenario : BaseScenario
    {
        public static async Task<Message> Start(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            //await botClient.SendChatActionAsync(
                //chatId: message.Chat.Id,
                //chatAction: ChatAction.Typing,
                //cancellationToken: cancellationToken);

            return await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Добро пожаловать!\n" +
                    "Перейдём к регистрации?",
                    cancellationToken: cancellationToken);
        }
    }
}

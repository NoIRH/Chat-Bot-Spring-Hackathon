using Controllers.Controllers;
using Controllers.Scenarios;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    public class ScenariosController : BaseController
    {
        public ScenariosController(DBController dBController) : base(dBController) { }

        public async Task<Message> RedirectToScenario(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            BaseScenario scenario;
            if (user == null)
            {
                scenario = new RegistrationScenario { Controller = this };
            }
            else
            {
                scenario = GetScenario(user.ScenarioId);
            }
            return await scenario.Start(botClient, message, cancellationToken, user);

            //if (user == null || user.ScenarioId == (int)TypeScenario.Start)
            //{
            //    scenario = new StartScenario { Controller = Controller }.Start(botClient, message, cancellationToken, user);
            //}
            //else if (user.ScenarioId == (int)TypeScenario.Registration)
            //{
            //    scenario = new RegistrationScenario { Controller = Controller }.Start(botClient, message, cancellationToken, user);
            //}
            //else if (user.ScenarioId == (int)TypeScenario.GenerationHero)
            //{
            //    scenario = new ControllerScenarios { Controller = Controller }.RedirectToScenario(botClient, message, cancellationToken, user);
            //}
            //else
            //{
            //    scenario = new BaseScenario { Controller = Controller }.PrintHelp(botClient, message, cancellationToken);
            //}
            //return await scenario;
        }

        public void Manage(User user, CallbackQuery callbackQuery)
        {
            if (user == null) throw new ArgumentNullException("user not found");
            GetScenario(user.ScenarioId).Solve(user, callbackQuery);
        }

        public BaseScenario GetScenario(int scenarioId)
        {
            if (scenarioId == (int)TypeScenario.Start)
            {
                return new StartScenario { Controller = this };
            }
            else if (scenarioId == (int)TypeScenario.Registration)
            {
                return new RegistrationScenario { Controller = this };
            }
            else if (scenarioId == (int)TypeScenario.GenerationHero)
            {
                return new GenerationHero { Controller = this };
            }
            else
            {
                return new BaseScenario { Controller = this };
            }
        }
    }
}

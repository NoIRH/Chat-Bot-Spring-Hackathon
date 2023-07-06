using Controllers.Controllers;
using Controllers.Scenarios;
using GeneralLibrary.BaseModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = GeneralLibrary.BaseModels.User;

namespace BotClient.Scenarios
{
    public class ScenariosController : BaseController
    {
        private GameController _gameController;

        public ScenariosController(DBController dBController) : base(dBController) 
        {
            _gameController = new GameController(_db);
        }

        public async Task<Message> RedirectToScenario(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, User user)
        {
            if (user == null)
            {
                return await new StartScenario { Controller = this }.Start(botClient, message, cancellationToken, user);
            }
            else
            {
                return await GetScenario(user.ScenarioId).Start(botClient, message, cancellationToken, user);
            }
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
            else if (scenarioId == (int)TypeScenario.SPECIAL)
            {
                return new SPECIALScenario { Controller = this };
            }
            else if (scenarioId == (int)TypeScenario.HotOrColdGame)
            {
                return new HotOrColdScenario { Controller = this, GameController = _gameController };
            }
            else
            {
                return new StartScenario { Controller = this };
            }
        }

        public List<Rate> GetRates() => _db.GetRates();
    }
}

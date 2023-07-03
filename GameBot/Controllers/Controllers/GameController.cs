
using GameEngine;
using GeneralLibrary.BaseModels;
using System.Diagnostics.SymbolStore;
using User = GeneralLibrary.BaseModels.User;

namespace Controllers.Controllers
{
    public class GameController : BaseController
    {

        public GameController(DBController db) : base(db) { }
        public void StartHotOrCold(User user, int start = 0, int end = 100)
        {
            HotOrCold hotOrCold = new HotOrCold();
            hotOrCold.Start(start,end);
            if(user.GameContext is null)
                user.GameContext = new Contexts.GameContext();
            user.GameContext.IsMiniGame = true;
            user.GameContext.MiniGame = hotOrCold;
        }
        public string HotOrColdNext(User user, int variant)
        {
            if (user.GameContext is not null && user.GameContext.MiniGame is not null)
            {
                var miniGame = ((HotOrCold)user.GameContext.MiniGame);
                var answer = miniGame.Guess(variant);
                user.GameContext.IsMiniGame = miniGame.IsWorked;
                return answer;  
            }
            return " вы что-то сломали !_)";
        }
    }
}

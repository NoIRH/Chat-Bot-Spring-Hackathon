﻿using GameEngine.MiniGames;
using User = GeneralLibrary.BaseModels.User;

namespace Controllers.Controllers
{
    public class GameController : BaseController
    {
        public GameController(DBController db) : base(db) { }
        #region calculation game
        public void StartCalculationGame(User user, int start = 0, int end = 100, int level = 1)
        {
            CalculationGame game = new CalculationGame();
            if (user.GameContext is null)
                user.GameContext = new Contexts.GameContext();
            user.GameContext.IsMiniGame = true;
            user.GameContext.MiniGame = game;
            game.Start(level, start, end);
        }
        public (string example, List<double> variants) CalculationGameNext(User user)
        {
            if (user.GameContext is not null && user.GameContext.MiniGame is not null)
            {
                var game = ((CalculationGame)user.GameContext.MiniGame);
                var e = game.GetNext();
                return e;
            }
            return (" вы что-то сломали !_)", null);
        }
        public void WriteAnswer(User user, double variant)
        {
            if (user.GameContext is not null && user.GameContext.MiniGame is not null)
            {
                var game = ((CalculationGame)user.GameContext.MiniGame);
                game.WriteAnswer(variant);
            }
        }
        public string GetCalculationGameStatistic(User user)
        {
            if (user.GameContext is not null && user.GameContext.MiniGame is not null) 
            {
                var game = ((CalculationGame)user.GameContext.MiniGame);
                return game.ShowStatistics();
            }
            return " вы что-то сломали !_)";
        }
        #endregion
        #region HotOrCold
        public void StartHotOrCold(User user, int start = 0, int end = 100)
        {
            HotOrCold hotOrCold = new HotOrCold();
            hotOrCold.Start(start, end);
            if (user.GameContext is null)
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
        #endregion

    }
}

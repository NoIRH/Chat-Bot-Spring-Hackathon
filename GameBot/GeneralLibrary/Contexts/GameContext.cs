using GameEngine.GameModels.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Contexts
{
    public class GameContext : BaseContext
    {
        public bool IsDungeon { get; set; }
        public bool IsFight { get; set; }
        public bool IsGenerationChar { get; set; }
        public bool IsMiniGame { get; set; }
        public Hero Opponent { get; set; }
        public Enemy Monster { get; set; }
    }
}

using GameEngine.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class GameContext : BaseContext
    {
        public bool IsDungeon { get; set; }
        public bool IsFight { get; set; }
        public Hero Opponent {get;set;}
        public Enemy Monster {get;set;}
    }
}

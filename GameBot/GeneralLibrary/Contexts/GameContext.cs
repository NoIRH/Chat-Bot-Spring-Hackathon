using GameEngine;
using GameEngine.GameModels.Characters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controllers.Contexts
{
    public class GameContext : BaseContext
    {
        public bool IsDungeon { get; set; }
        public bool IsFight { get; set; }
        public bool IsGenerationChar { get; set; }
        public bool IsMiniGame { get; set; }
        [NotMapped]
        public MiniGame? MiniGame { get; set; }
        public Hero Opponent { get; set; }
        public Enemy Monster { get; set; }
    }
}

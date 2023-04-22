using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.GameModels.CharDescription;

namespace GameEngine.GameModels
{
    public class Hero : BaseCharacter
    {
        public int Expirience { get; set; } // будет опредлять уровень как логарифм по основанию 2 
        public int PowerPoints { get; set; }
        public void UpdateStatus() { }
        public void GetStatistics() { }
        public void GoDange() { }
        public void GoMiniGames() { }
        public void Fight() { }

    }
}

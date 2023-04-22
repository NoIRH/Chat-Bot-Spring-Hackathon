using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameModels.CharDescription
{
    public class Status
    {
        public int Id { get; set; }
        public int HitPoints { get; set; }
        public int Energy { get; set; }
        public int Stamina { get; set; }
        public int AttackMin { get; set; }
        public int AttackMax { get; set; }
        #region SPECIAL
        public int Strength { get; set; }
        public int Perception { get; set; }
        public int Endurance { get; set; }
        public int Charisma { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }
        #endregion
        public int CarryWeight { get; set; }
        public int Mood { get; set; }

    }
}

using GameEngine.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Fight
    {
        public int Id { get; set; } 
        public string Name { get; set; } // H1 VS H2 
        public BaseCharacter Character1 { get; set; }
        public BaseCharacter Character2 { get; set;}
        public int CurrentStep { get; set; }
        public int HitPointsChar1 { get; set; }
        public int HitPointsChar2 { get;set; }
        public void Attack() { } // first attack second after current step++
        public void UseItem() { }
        private void CheckDie() { }
        public void EndFight() { }
    }
}

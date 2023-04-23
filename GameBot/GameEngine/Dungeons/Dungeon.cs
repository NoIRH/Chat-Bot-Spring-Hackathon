using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Dungeons
{
    public class Dungeon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; } //  сложность
        public int Depth { get; set; }  //  колчиство развилок
        public int DungeonType { get; set; } //  потом сделать класс 
        public int CurrentStep { get; set; }
        public DungeonFork Fork { get; set; }
        public Fight Fight { get; set; }

        public void InitFight() { }
        public void InitExam() { }
        public void GenerateEnemy() { }
        public void SelectVariant() { }
        public void DoStep() { }

    }
}

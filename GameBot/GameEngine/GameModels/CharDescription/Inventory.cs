using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.GameModels.Characters;
using GameEngine.GameModels.Items;

namespace GameEngine.GameModels.CharDescription
{
    public class Inventory
    {
        private BaseCharacter _master;
        private Inventory() { }
        public Inventory(BaseCharacter master)
        {
            _master = master;
            Items = new List<Item>();
        }
        public int Id { get; set; }
        public int CurrentWeight { get; set; }
        public int MaxWeight { get; set; }
        public List<Item> Items { get; set; } = new();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.GameModels.CharDescription;

namespace GameEngine.GameModels.DbView
{
    public class InventoryItems
    {
        public int Id { get; set; }
        public Inventory Inventory { get; set; }
        public Item Item { get; set; }
    }
}

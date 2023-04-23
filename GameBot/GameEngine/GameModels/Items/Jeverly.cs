using GameEngine.GameModels.CharDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameModels.Items
{
    public class Jeverly : Item
    {
        public bool IsWeared { get; set; }
        public List<Equipment> Equipment { get; set; } = new();
    }
}

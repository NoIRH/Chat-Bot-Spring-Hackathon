using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.GameModels.Items;

namespace GameEngine.GameModels.CharDescription
{
    public class Equipment
    {
        public int Id { get; set; } 
        public List<Armor> Armors { get; set; } 
        public List<Weapon> Weapons { get; set; }
        public List<Jeverly> Jeverlys { get; set; }
    }
}

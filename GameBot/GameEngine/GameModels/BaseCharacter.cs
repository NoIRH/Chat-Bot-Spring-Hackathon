using GameEngine.GameModels.CharDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameModels
{
    public class BaseCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterSpecialization Specialization { get; set; }
    }
}

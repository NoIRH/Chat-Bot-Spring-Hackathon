using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.GameModels;

namespace GeneralLibrary.BaseModels
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Role Role { get; set; }
        //remake this
        public string Department { get; set; }
        
        public Hero? Hero { get; set; }
        public List<Achievement> Achievements { get; set;}
        // NEED TO FINISH 

    }
}

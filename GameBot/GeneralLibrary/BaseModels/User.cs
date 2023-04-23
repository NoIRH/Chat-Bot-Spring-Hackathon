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
<<<<<<< HEAD

=======
        public int ChatId { get; set; }
>>>>>>> 2d83a9dea8c3271799ce90f79ee4bfbdfd8b8ee4
        public string Name { get; set; }

        public Role Role { get; set; }
        //remake this

        public string Department { get; set; }
        public Hero? Hero { get; set; }

        public List<Achievement> Achievements { get; set; } = new();
<<<<<<< HEAD
        // NEED TO FINISH 

=======
>>>>>>> 2d83a9dea8c3271799ce90f79ee4bfbdfd8b8ee4
        public int ScenarioId { get; set; }

        public int CurrentScenarioStep { get; set; }    

        public int ClanId { get; set; }

        public Clan? Clan { get; set; }
        // NEED TO FINISH 
    }
}

﻿using Controllers.Contexts;
using GameEngine.GameModels.Characters;

namespace GeneralLibrary.BaseModels
{
    public class User
    {
        public int Id { get; set; } 

        public int ChatId { get; set; }

        public string Name { get; set; }

        public Role? Role { get; set; }
        //remake this

        public string? Department { get; set; }

        public Hero? Hero { get; set; }

        public List<Achievement> Achievements { get; set; } = new();
        // NEED TO FINISH 

        public int ScenarioId { get; set; }

        public int CurrentScenarioStep { get; set; }    

        public int? ClanId { get; set; }

        public Clan? Clan { get; set; }
        // NEED TO FINISH 
        public GameContext? GameContext { get; set; }   
    }
}

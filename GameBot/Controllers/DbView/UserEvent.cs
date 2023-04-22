using Controllers.EventSystem;
using GeneralLibrary.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.DbView
{
    public class UserEvent
    {
        public int Id { get; set; }
        public User User { get; set; }
        public BaseEvent Event {get; set; } 
        public bool IsInitiator { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.EventSystem
{
    public class BaseEvent
    {
        public int Id { get; set; } 

        public bool IsFinished { get; set; }
    }
}

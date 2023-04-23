using Controllers.EventSystem;
using GeneralLibrary.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Contexts
{
    public class BaseContext
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<BaseEvent> Events { get; set; } = new();
    }
}

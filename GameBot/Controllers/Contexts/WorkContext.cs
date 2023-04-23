using Controllers.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Contexts
{
    public class WorkContext : BaseContext
    {
        public List<BaseEvent> CurrentEvents { get; set; }
        public bool IsRegistration { get; set; }
    }
}

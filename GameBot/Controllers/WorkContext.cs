using Controllers.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class WorkContext : BaseContext
    {
        public List<BaseEvent> CurrentEvents {  get; set; }
    }
}

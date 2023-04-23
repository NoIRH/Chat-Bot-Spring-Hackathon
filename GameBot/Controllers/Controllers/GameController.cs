using GeneralLibrary.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    public class GameController
    {
        public List<User> Users { get; set; }
       

        public GameController() { }
        public GameController(DBController dB) 
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLibrary.BaseModels
{
    public class Clan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // need to add list users and probably something else
        public List<User> Users { get; set; } = new();
    }
}

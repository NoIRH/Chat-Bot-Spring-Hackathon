using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLibrary.BaseModels
{
    public class Rate
    {
        public int Id { get; set; } 
        public  User User { get; set; }
        public double Mark { get; set; }
    }
}

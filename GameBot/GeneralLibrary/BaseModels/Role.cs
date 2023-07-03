using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLibrary.BaseModels
{
    public enum TypeRole
    {
        MainAdmin = 0,
        Admin = 1,
        User = 2
    }
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TypeRole? Type { get; set; }  
    }
}

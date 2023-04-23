using GeneralLibrary.BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    public class DBController
    {
        private readonly DbContext _dbContext;
        public DBController(DbContext context) 
        {
            _dbContext = context;
        }
       /* public List<User> GetUsers()
        {
           // return _dbContext.Database
        }*/
    }
}

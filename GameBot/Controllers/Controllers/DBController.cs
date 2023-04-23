using Controllers.Contexts;
using Controllers.DbView;
using Controllers.EventSystem;
using DBServises.Servises;
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
        private readonly ApplicationContext _dbContext;
        public DBController(ApplicationContext context) 
        {
            _dbContext = context;
        }
        public List<User> GetUsers() => _dbContext.Users.Include(u => u.Achievements).ToList();
        public List<Statistic> GetStatistics() => _dbContext.Statistics.ToList(); 
        public List<Rate> GetRates() => _dbContext.Rate.ToList();
        public List<Clan> GetClans() => _dbContext.Clans.Include(c => c.Users).ToList();
        public List<Achievement> GetAchievements() => _dbContext.Achievements.Include(a => a.Users).ToList();
        public List<BaseContext> GetBaseContexts() => _dbContext.BaseContexts.Include(b => b.Events).ToList();
        public List<GameContext> GetGameContexts() => _dbContext.GameContexts.Include(b => b.Events).ToList();
        public List<WorkContext> GetWorkContexts() => _dbContext.WorkContexts.Include(b => b.Events).ToList();
        public List<UserEvent> GetUserEvents() => _dbContext.UserEvents.ToList();
      //  public List<BaseEvent> GetBaseEvents() => _dbContext.BaseEve.Include(b => b.)

    }
}

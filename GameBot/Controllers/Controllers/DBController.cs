using Controllers.Contexts;
using Controllers.DbView;
using Controllers.EventSystem;
using DBServises.Servises;
using GameEngine;
using GameEngine.Dungeons;
using GameEngine.GameModels.Characters;
using GameEngine.GameModels.CharDescription;
using GameEngine.GameModels.Items;
using GameEngine.GameModels.Skills;
using GeneralLibrary.BaseModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Controllers.Controllers
{
    public class DBController
    {
        private readonly ApplicationContext _dbContext;
        public DBController(ApplicationContext context)
        {
            _dbContext = context;
        }
        //public List<User> GetUsers() => _dbContext.Users.Include(u => u.Achievements).ToList();
        public List<User> GetUsers() => _dbContext.Users.Include(u => u.Achievements).Include(u => u.Hero).Include(u => u.Hero.Class).Include(u => u.Hero.StatusBase).ToList();

        public List<Statistic> GetStatistics() => _dbContext.Statistics.ToList();
        public List<Rate> GetRates() => _dbContext.Rate.ToList();
        public List<Clan> GetClans() => _dbContext.Clans.Include(c => c.Users).ToList();
        public List<Achievement> GetAchievements() => _dbContext.Achievements.Include(a => a.Users).ToList();
        public List<BaseContext> GetBaseContexts() => _dbContext.BaseContexts.Include(b => b.Events).ToList();
        public List<GameContext> GetGameContexts() => _dbContext.GameContexts.Include(b => b.Events).ToList();
        public List<WorkContext> GetWorkContexts() => _dbContext.WorkContexts.Include(b => b.Events).ToList();
        public List<UserEvent> GetUserEvents() => _dbContext.UserEvents.ToList();
        public List<BaseEvent> GetBaseEvents() => _dbContext.BaseEvents.Include(b => b.Contexts).ToList();
        public List<GameEvent> GetGameEvents() => _dbContext.GameEvents.Include(b => b.Contexts).ToList();
        public List<WorkEvent> GetWorkEvents() => _dbContext.WorkEvents.Include(b => b.Contexts).ToList();
        public List<BaseCharacter> GetBaseCharacters() => _dbContext.Characters.ToList();
        public List<Hero> GetHeroes() => _dbContext.Heroes.Include(h => h.Class).ToList();
        public List<Enemy> GetEnemies() => _dbContext.Enemyes.ToList();
        public List<Fight> GetFights() => _dbContext.Fights.ToList();
        public List<Item> GetItems() => _dbContext.Items.Include(i => i.Inventories).ToList();
        public List<Armor> GetArmors() => _dbContext.Armors.
            Include(i => i.Inventories).
            Include(i => i.Equipment).
            ToList();
        public List<Weapon> GetWeapons() => _dbContext.Weapons.
           Include(i => i.Inventories).
           Include(i => i.Equipment).
           ToList();
        public List<Jeverly> GetJeverlies() => _dbContext.Jeverlies.
           Include(i => i.Inventories).
           Include(i => i.Equipment).
           ToList();
        public List<Potion> GetPotions() => _dbContext.Potions.Include(i => i.Inventories).ToList();
        public List<Skill> GetSkills() => _dbContext.Skills.ToList();
        public List<AttackSkill> GetAttackSkills() => _dbContext.Attacks.ToList();
        public List<BuffSkill> GetBuffSkills() => _dbContext.Buffs.ToList();
        public List<DebuffSkill> GetDebuffSkills() => _dbContext.Debuffs.ToList();
        public List<HealSkill> GetHealSkills() => _dbContext.Heals.ToList();
        public List<Status> GetStatuses() => _dbContext.Statuses.ToList();
        public List<Inventory> GetInventories() => _dbContext.Inventories.Include(i => i.Items).ToList();
        public List<Equipment> GetEquipment() => _dbContext.Equipment.
            Include(e => e.Armors).
            Include(e => e.Weapons).
            Include(e => e.Jeverlys).
            ToList();
        public List<CharacterClass> GetCharacterSpecializations() => _dbContext.Specializations.ToList();
        public List<Dungeon> GetDungeons() => _dbContext.Dungeons.Include(d => d.Fork).ToList();
        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            UpdateData();
        }

        public void UpdateData()
        {
            try
            {
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}

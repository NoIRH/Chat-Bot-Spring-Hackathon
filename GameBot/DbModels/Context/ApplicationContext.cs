using BotClient.Scenarios;
using Controllers.Contexts;
using Controllers.DbView;
using GameEngine;
using GameEngine.Dungeons;
using GameEngine.GameModels;
using GameEngine.GameModels.CharDescription;
using GameEngine.GameModels.DbView;
using GameEngine.GameModels.Items;
using GameEngine.GameModels.Skills;
using GeneralLibrary.BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServises.Servises
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }  
        public DbSet<Role> Roles { get; set; } 
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Achievement> Achievements { get; set; }   
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<Clan> Clans { get; set; }  
        public DbSet<BaseCharacter> Characters { get; set; }
        public DbSet<CharacterSpecialization> Specializations { get; set; } 
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Enemy> Enemyes { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Armor> Armors { get; set; } 
        public DbSet<Weapon> Weapons { get; set; } 
        public DbSet<Jeverly> Jeverlies { get; set; }
        public DbSet<Potion> Potions { get; set; }  
        public DbSet<InventoryItems> InventoryItems { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Fight> Fights { get; set; }    
        public DbSet<Skill> Skills { get; set; }
        public DbSet<AttackSkill> Attacks { get; set; } 
        public DbSet<BuffSkill> Buffs { get; set; }
        public DbSet<DebuffSkill> Debuffs { get; set; }
        public DbSet<HealSkill> Heals { get; set; } 
        public DbSet<Dungeon> Dungeons { get; set; }    
        public DbSet<BaseContext> BaseContexts { get; set; }
        public DbSet<GameContext> GameContexts { get; set; }  
        public DbSet<WorkContext> WorkContexts { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }   
        public DbSet<BaseScenario> Scenarios { get; set; }  
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=31428");
        }
    }
}

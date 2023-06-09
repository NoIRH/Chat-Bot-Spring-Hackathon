﻿using GeneralLibrary.BaseModels;

namespace Controllers.Controllers
{
    public class BaseController
    {
        protected DBController _db;

        public List<User> Users { get; set; }

        public BaseController() { }

        public BaseController(DBController dB)
        {
            _db = dB;
            Users = dB.GetUsers();
        }

        public User GetUser(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _db.AddUser(user);
            Users = _db.GetUsers();
        }

        public void UpdateDataDB()
        {
            _db.UpdateData();
        }
    }
}
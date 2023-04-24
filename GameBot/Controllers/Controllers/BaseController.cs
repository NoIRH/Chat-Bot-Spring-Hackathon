using GeneralLibrary.BaseModels;

namespace Controllers.Controllers
{
    public class BaseController
    {
        public List<User> Users { get; set; }
        public DBController _dB;
        public BaseController() { } 
        public BaseController(DBController dB)
        {
            _dB = dB;
            Users = _dB.GetUsers();
        }
        public User GetUser(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }
        public void AddUser(User u)
        {
            _dB.AddUser(u);
        }
    }
}
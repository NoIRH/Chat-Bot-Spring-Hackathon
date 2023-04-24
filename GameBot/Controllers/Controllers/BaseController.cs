using GeneralLibrary.BaseModels;

namespace Controllers.Controllers
{
    public class BaseController
    {
        public List<User> Users { get; set; }
        public BaseController() { } 
        public BaseController(DBController dB)
        {
            Users = dB.GetUsers();
        }
        public User GetUser(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
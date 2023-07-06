using Controllers.EventSystem;
using GeneralLibrary.BaseModels;

namespace Controllers.Contexts
{
    public class BaseContext
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<BaseEvent> Events { get; set; } = new();
    }
}

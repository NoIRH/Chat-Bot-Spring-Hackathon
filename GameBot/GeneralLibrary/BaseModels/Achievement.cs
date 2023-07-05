
namespace GeneralLibrary.BaseModels
{
    public class Achievement
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<User?>? Users { get; set; } = new();
    }
}

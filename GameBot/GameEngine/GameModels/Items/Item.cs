using GameEngine.GameModels.CharDescription;

namespace GameEngine.GameModels.Items
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public Status ModStatus { get; set; }
        public List<Inventory> Inventories { get; set; } = new();
    }
}

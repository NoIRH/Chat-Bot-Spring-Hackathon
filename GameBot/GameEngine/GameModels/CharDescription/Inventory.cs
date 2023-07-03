using GameEngine.GameModels.Items;

namespace GameEngine.GameModels.CharDescription
{
    public class Inventory
    {
        public Inventory() { }

        public int Id { get; set; }
        public int CurrentWeight { get; set; }
        public int MaxWeight { get; set; }
        public List<Item> Items { get; set; } = new();

    }
}

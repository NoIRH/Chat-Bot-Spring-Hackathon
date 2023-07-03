using GameEngine.GameModels.CharDescription;

namespace GameEngine.GameModels.Characters
{
    public class BaseCharacter
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public Status? StatusBase { get; set; }

        public Status? StatusCurrent { get; set; }

        public Inventory? Inventory { get; set; }

        public CharacterClass? Class { get; set; }

        public void UpdateStatus() { }
    }
}

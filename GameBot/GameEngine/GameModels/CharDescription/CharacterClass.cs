
namespace GameEngine.GameModels.CharDescription
{
    public enum TypeClass
    {
        Wizard = 0,
        Warrior = 1,
        Thief = 2,
        Berserk = 4,
        Bard = 8,
        Paladin = 16
    }

    public class CharacterClass
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public TypeClass Class { get; set; }
    }
}

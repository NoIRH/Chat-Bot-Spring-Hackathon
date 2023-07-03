using GameEngine.GameModels.CharDescription;

namespace GameEngine.GameModels.Characters
{
    public class Hero : BaseCharacter
    {
        public int Expirience { get; set; } // будет опредлять уровень как логарифм по основанию 2

        public int PowerPoints { get; set; }

        public int CountMoney { get; set; }

        public string ImageSource { get; set; }

        public void GetStatistics() { }

        public void GoDange() { }

        public void GoMiniGames() { }

        public void Fight() { }

        public void ChangeAvatar() { }

        public void UseItem() { }

        public void ShowInventory() { }

        public void HideInventory() { }

        public void PutOnArmor() { }

        public void RemoveOnArmor() { }

        public void PutOnWeapon() { }

        public void RemoveOnWeapon() { }

        public void PutOnJeverly() { }

        public void RemoveOnJeverly() { }
    }
}

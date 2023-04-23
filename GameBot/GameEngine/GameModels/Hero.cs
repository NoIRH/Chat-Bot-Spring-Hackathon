using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.GameModels.CharDescription;

namespace GameEngine.GameModels
{
    public class Hero : BaseCharacter
    {
        public int Expirience { get; set; } // будет опредлять уровень как логарифм по основанию 2 
        public int PowerPoints { get; set; }
        public int CountMoney { get; set; }
        public string ImageSource { get; set; }


        public void UpdateStatus() { }
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

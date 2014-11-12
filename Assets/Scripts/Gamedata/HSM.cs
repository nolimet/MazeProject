using UnityEngine;
using System.Collections;

namespace gameData
{
    public class HSM
    {
        //Heatlh
        //Stamina
        //Mana

        public const int maxStamina = 100, maxHealth = 100, maxMana = 100;
        public static float Health = 100, Stamina = 100 , Mana = 100;

        public static bool canCast(int cost)
        {
            if (Mana >= cost)
                return true;
            else
                return false;
        }
    }
}
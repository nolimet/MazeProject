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

        public static bool CastSpell(int cost)
        {
            if (Mana >= cost)
            {
                Mana -= cost;
                return true;
            }
            else
                return false;
        }
    }
}
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
        public static Transform Player,Camera;

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

        public static void Heal(int amount)
        {
            if (Health < maxHealth)
            {
                Health += amount;
                if (Health > maxHealth)
                    Health = maxHealth;
            }
        }

        public static void restoreStamina(int amount)
        {
            if (Stamina < maxStamina)
            {
                Stamina += amount;
                if (Stamina > maxStamina)
                    Stamina = maxStamina;
            }
        }

        public static bool CanHeal()
        {
            if (Health < maxHealth)
                return true;
            else
                return false;
        }

        public static bool CanStamina()
        {
            if (Stamina < maxStamina)
                return true;
            else
                return false;
        }
    }

    
}
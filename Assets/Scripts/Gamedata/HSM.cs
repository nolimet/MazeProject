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

        public static bool CastSpell(float cost)
        {
            if (Mana >= cost)
            {
                Mana -= cost;
                return true;
            }
            else
                return false;
        }

        public static void Heal(float amount)
        {
            if (Health < maxHealth)
            {
                Health += amount;
                if (Health > maxHealth)
                    Health = maxHealth;
            }
        }

        public static void restoreStamina(float amount)
        {
            if (Stamina < maxStamina)
            {
                Stamina += amount;
                if (Stamina > maxStamina)
                    Stamina = maxStamina;
            }
        }

        public static void takeStamina(float amount)
        {
            if (Stamina > 0)
            {
                Stamina -= amount;
                if (Stamina < 0)
                    Stamina = 0;
            }
        }

        public static void restoreMana(float amount)
        {
            if (Mana < maxMana)
            {
                Mana += amount;
                if (Mana > maxMana)
                    Mana = maxMana;
            }
        }

        public static bool CanHeal()
        {
            if (Health < maxHealth)
                return true;
            else
                return false;
        }

        public static bool CanStamina(bool invert = false, float value=0)
        {
            if (!invert)
            {
                if (Stamina < maxStamina)
                    return true;
                else
                    return false;
            }
            else
            {
                if (Stamina >= value)
                    return true;
                else
                    return false;
            }
        }
    }

    
}
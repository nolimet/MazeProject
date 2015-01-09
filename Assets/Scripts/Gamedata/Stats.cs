using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace gameData
{
    [System.SerializableAttribute]
    public class Stats : MonoBehaviour
    {
#region Data Class
        [System.Serializable]
        public class microData
        {
            public DMGTypes weak = DMGTypes.None;
            public DMGTypes mid = DMGTypes.None;
            public DMGTypes strong = DMGTypes.None;

            public microData(DMGTypes _weak = DMGTypes.None, DMGTypes _mid = DMGTypes.None, DMGTypes _strong = DMGTypes.None)
            {
                weak = _weak;
                mid = _mid;
                strong = _strong;
            }
        }

        [System.Serializable]
        public class dmgData
        {
            public DMGTypes[] dmgTypes;
            public float dmg;

            public dmgData(float damage, DMGTypes[] types)
            {
                dmgTypes = types;
                dmg = damage;
            }
        }

        public enum DMGTypes
        {
            None,
            Fire,
            Water,
            Ice,
            Earth,
            Lightning,
            Piercing,
            Impact,
            Slash,
            Arcane,
            Bleeding,
            Poison
        }
        #endregion

        public float health = 10, maxHealth, armor = 20, level = 0;
        [Range(1f,2f)]
        public float hpScaling = 1.2f;
        public microData resistances = new microData();
        public microData weaknesses = new microData();

        void Start()
        {
            maxHealth = Mathf.Round(maxHealth * Mathf.Pow(hpScaling,level));
            health = maxHealth;
        }

        void Heal(float amount)
        {
            if (health < maxHealth)
            {
                health += amount;
                if (health > maxHealth)
                    health = maxHealth;
            }
        }

        void TakeDMG(dmgData data)
        {
            foreach (DMGTypes d in data.dmgTypes)
            {
                if (d != DMGTypes.None)
                {
                    if (resistances.weak == d)
                        data.dmg /= 1.25f;
                    else if (resistances.mid == d)
                        data.dmg /= 1.5f;
                    else if (resistances.strong == d)
                        data.dmg /= 2f;
                    else if (weaknesses.weak == d)
                        data.dmg *= 1.25f;
                    else if (weaknesses.mid == d)
                        data.dmg *= 1.5f;
                    else if (weaknesses.strong == d)
                        data.dmg *= 2f;
                }
            }

            health -= data.dmg;
            if (health <= 0)
            {
                renderer.material.color += Color.red;
                health = 0;
            }
            
        }
    }
}
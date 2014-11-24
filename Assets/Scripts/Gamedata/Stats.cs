using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace gameData
{
    public class Stats : MonoBehaviour
    {
        [System.Serializable]
        public class microData
        {
            public DMGTypes weak = DMGTypes.None;
            public DMGTypes mid = DMGTypes.None;
            public DMGTypes strong = DMGTypes.None;

            public microData(DMGTypes _weak, DMGTypes _mid, DMGTypes _strong)
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
            Slash
        }

        public float health = 10, armor = 0, level = 1, hpScaling = 1.2f;
        public microData resistances;
        public microData weaknesses;

        void Start()
        {
            health *= Mathf.Pow(hpScaling, level - 1);
        }

        void TakeDMG(dmgData data)
        {
            foreach (DMGTypes d in data.dmgTypes)
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

            health -= data.dmg;
            if (health <= 0)
                renderer.material.color += Color.red;
            print(health);
        }
    }
}
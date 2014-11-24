using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stats : MonoBehaviour {

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

    public float health = 10, armor = 0 , level = 1, hpScaling = 1.2f;
    public microData resistances;
    public microData weaknesses;

    void Start()
    {
        health *= Mathf.Pow(hpScaling, level-1);
    }

    public void takeDMG(float dmg, DMGTypes[] dmgType)
    {
        foreach(DMGTypes d in dmgType)
        {
            if (resistances.weak == d)
                dmg /= 1.25f;
            else if (resistances.mid == d)
                dmg /= 1.5f;
            else if (resistances.strong == d)
                dmg /= 2f;
            else if (weaknesses.weak == d)
                dmg *= 1.25f;
            else if (weaknesses.mid== d)
                dmg *= 1.5f;
            else if (weaknesses.strong == d)
                dmg *= 2f;
        }
    }
    [System.Serializable]
    public class microData
    {
        public DMGTypes weak = DMGTypes.None;
        public DMGTypes mid = DMGTypes.None;
        public DMGTypes strong = DMGTypes.None;
    }
    
}

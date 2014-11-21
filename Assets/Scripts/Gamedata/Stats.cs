using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stats : MonoBehaviour {

    public enum DMGTypes
    {
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
    public List<DMGTypes> resistances = new List<DMGTypes>();

    void Start()
    {
        health *= Mathf.Pow(hpScaling, level-1);
    }

    public void takeDMG(float dmg, DMGTypes[] dmgType)
    {
        foreach(DMGTypes d in dmgType)
        {
            if (resistances.Contains(d))
                dmg /= 1.25f;
        }
    }

    
}

using UnityEngine;
using System.Collections;
using gameData;

public class MagicSpells : MonoBehaviour {

    public const string spellPath = "spells/";
    public enum AoESpells
    {
        fireBall
    }

    public enum SelfSpells
    {
        heal,
        staminaBoost
    }

    public static void CastAoE(AoESpells spell)
    {
        string type = "target/";
        GameObject sp = null;
        switch (spell)
        {
            case AoESpells.fireBall:
                if (HSM.CastSpell(10))
                {
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + type + "basicAoE"));
                }
                break;
        }
        if (sp != null)
        {
            sp.transform.position = HSM.Player.position + HSM.Player.forward * 1.3f;
            sp.transform.rotation = Camera.main.transform.rotation;
        }
    }

    public static void CastSelf(SelfSpells spell)
    {
        string type = "self/";
        GameObject sp = null;
        switch (spell)
        {
            case SelfSpells.heal:
                if (HSM.CanHeal()&&HSM.CastSpell(20))
                {
                    HSM.Heal(10);
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + type + "Heal"));
                }
                break;
            case SelfSpells.staminaBoost:
                if (HSM.CanStamina() && HSM.CastSpell(10))
                {
                    HSM.restoreStamina(15);
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + type + "Stamina"));
                }
                break;
        }
        print(spell.ToString());
        if (sp != null)
        {
            sp.transform.parent = HSM.Player;
            sp.transform.localPosition = new Vector3(0, -1, 0);
            Destroy(sp, 10f);
        }
    }
}

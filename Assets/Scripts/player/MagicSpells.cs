using UnityEngine;
using System.Collections;
using gameData;

public class MagicSpells : MonoBehaviour {

    public const string spellPath = "spells/";
    public static Transform Player;
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
        switch (spell)
        {
            case AoESpells.fireBall:
                if (HSM.CastSpell(10))
                {

                }
                break;
        }
    }

    public static void CastSelf(SelfSpells spell)
    {
        string self = "self/";
        GameObject sp = null;
        switch (spell)
        {
            case SelfSpells.heal:
                if (HSM.CanHeal()&&HSM.CastSpell(20))
                {
                    HSM.Heal(10);
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + self + "Heal"));
                }
                break;
            case SelfSpells.staminaBoost:
                if (HSM.CanStamina() && HSM.CastSpell(10))
                {
                    HSM.restoreStamina(15);
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + self + "Stamina"));
                }
                break;
        }
        print(spell.ToString());
        if (sp != null)
        {
            sp.transform.parent = Player;
            sp.transform.localPosition = new Vector3(0, -1, 0);
            Destroy(sp, 10f);
        }
    }
}

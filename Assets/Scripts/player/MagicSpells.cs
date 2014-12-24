using UnityEngine;
using System.Collections;
using gameData;
using managers;

public class MagicSpells : MonoBehaviour {

    public const string spellPath = "spells/";
    public enum AoESpells
    {
        fireBall = 0,
        Lightnin = 1
    }

    public enum SelfSpells
    {
        heal = 0,
        staminaBoost = 1,
        manaBoost = 2,
        regeneration = 3
    }

    public static void CastAoE(AoESpells spell)
    {
        string type = "target/";
        GameObject sp = null;
        switch (spell)
        {
            case AoESpells.fireBall:
                if (HSM.CastSpell(40))
                {
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + type + "basicAoE"));
                }
                break;
            case AoESpells.Lightnin:
                if (HSM.CastSpell(70))
                {
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + type + "BasicChain"));
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
                if (HSM.CanHeal()&&HSM.CastSpell(30))
                {
                    HSM.Heal(20);
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + type + "Heal"));
                }
                break;
            case SelfSpells.staminaBoost:
                if (HSM.CanStamina() && HSM.CastSpell(30))
                {
                    StatusEffect.EffectStarter(new StatusEffect.StatusData(StatusEffect.effects.StaminaRegen, HSMManager.instance.gameObject, 30f), 2f);
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + type + "Stamina"));
                }
                break;
            case SelfSpells.manaBoost:
                if (HSM.CanStamina(true, 40f))
                {
                    StatusEffect.EffectStarter(new StatusEffect.StatusData(StatusEffect.effects.ManaRegen, HSMManager.instance.gameObject, 30f), 2f);
                    HSM.takeStamina(20f);
                }
                break;
            case SelfSpells.regeneration:
                if (HSM.CanHeal() && HSM.CastSpell(60))
                {
                    StatusEffect.EffectStarter(new StatusEffect.StatusData(StatusEffect.effects.Regeneration, HSMManager.instance.gameObject, 50f), 2f);
                    sp = (GameObject)Instantiate(Resources.Load(spellPath + type + "Heal"));
                }
                break;
        }
        if (sp != null)
        {
            sp.transform.parent = HSM.Player;
            sp.transform.localPosition = new Vector3(0, -1, 0);
            Destroy(sp, 10f);
        }
    }
}

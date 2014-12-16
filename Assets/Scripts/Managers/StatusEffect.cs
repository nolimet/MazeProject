using UnityEngine;
using System.Collections;
using gameData;
public class StatusEffect : MonoBehaviour
{

    const int DMGTPS = 20;

    public enum effects
    {
        Bleeding,
        Burning,
        Regeneration,
        StaminaRegen,
        ManaRegen,
        Binden,
        Blinded,
        Slowness,
        Poisened

    }
    public static void EffectStarter(StatusData effect, float duration)
    {
        StaticCoroutine.DoCoroutine(StartEffect(effect, duration));  
    }

    public static IEnumerator StartEffect(StatusData effect, float duration)
    {
        print("Started routine");
        float TotalDuration = duration;
        float waitTime = 1f / DMGTPS;
        if (effect.target.tag == tags.PLAYER)
        {
            print("player");
            while (duration > 0)
            {
                duration -= waitTime;
                // effect.target.SendMessage("TakeDMG", new  Stats.dmgData(effect.totalDmg / TotalDuration, effect.status), SendMessageOptions.DontRequireReceiver);
                ExcuteEffectPlayer(effect, TotalDuration);
                yield return new WaitForSeconds(waitTime);
            }
        }

        if (effect.target.tag == tags.MOB)
        {
            while (duration > 0)
            {
                duration -= waitTime;
                // effect.target.SendMessage("TakeDMG", new  Stats.dmgData(effect.totalDmg / TotalDuration, effect.status), SendMessageOptions.DontRequireReceiver);
                
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

    public static void ExcuteEffectPlayer(StatusData data, float duration)
    {
        switch (data.status)
        {
            case effects.Burning:
                data.target.SendMessage("TakeDMG", new Stats.dmgData(data.totalDmg / duration / DMGTPS, new Stats.DMGTypes[] { Stats.DMGTypes.Fire }), SendMessageOptions.DontRequireReceiver);
                break;

            case effects.Bleeding:
                data.target.SendMessage("TakeDMG", new Stats.dmgData(data.totalDmg / duration / DMGTPS, new Stats.DMGTypes[] { Stats.DMGTypes.Slash, Stats.DMGTypes.Impact }), SendMessageOptions.DontRequireReceiver);
                break;

            case effects.Poisened:
                data.target.SendMessage("TakeDMG", new Stats.dmgData(data.totalDmg / duration / DMGTPS, new Stats.DMGTypes[] { Stats.DMGTypes.Poison }), SendMessageOptions.DontRequireReceiver);
                break;

            case effects.Slowness:
                data.target.SendMessage("TakeDMG", new Stats.dmgData(data.totalDmg / duration / DMGTPS, new Stats.DMGTypes[] { Stats.DMGTypes.Ice }), SendMessageOptions.DontRequireReceiver);
                break;
            case effects.Regeneration:
                HSM.Heal(data.totalDmg / duration / DMGTPS);
                break;
            case effects.StaminaRegen:
                HSM.restoreStamina(data.totalDmg / duration / DMGTPS);
                break;
            default:
                break;

        }
    }

    public static void ExcuteEffectMonster(StatusData data)
    {

    }
    public class StatusData
    {
        public effects status;
        public GameObject target;
        public float totalDmg;

        public StatusData(effects status, GameObject target, float totalDmg)
        {
            this.status = status;
            this.target = target;
            this.totalDmg = totalDmg;
        }
    }
}

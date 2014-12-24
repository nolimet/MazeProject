using UnityEngine;
using System.Collections;
using gameData;

namespace managers
{
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
            Bindend,
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
            float TotalDuration = duration;
            float waitTime = 1f / DMGTPS;
            if (effect.target.tag == tags.PLAYER)
            {
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
            float callculatedDMG = data.totalDmg / duration / DMGTPS;
            switch (data.status)
            {
                case effects.Burning:
                    data.target.SendMessage("TakeDMG", new Stats.dmgData(callculatedDMG, new Stats.DMGTypes[] { Stats.DMGTypes.Fire }), SendMessageOptions.DontRequireReceiver);
                    break;

                case effects.Bleeding:
                    data.target.SendMessage("TakeDMG", new Stats.dmgData(callculatedDMG, new Stats.DMGTypes[] { Stats.DMGTypes.Slash, Stats.DMGTypes.Impact }), SendMessageOptions.DontRequireReceiver);
                    break;

                case effects.Poisened:
                    data.target.SendMessage("TakeDMG", new Stats.dmgData(callculatedDMG, new Stats.DMGTypes[] { Stats.DMGTypes.Poison }), SendMessageOptions.DontRequireReceiver);
                    break;

                case effects.Slowness:
                    data.target.SendMessage("TakeDMG", new Stats.dmgData(callculatedDMG, new Stats.DMGTypes[] { Stats.DMGTypes.Ice }), SendMessageOptions.DontRequireReceiver);
                    break;
                case effects.Regeneration:
                    HSM.Heal(callculatedDMG);
                    break;
                case effects.StaminaRegen:
                    HSM.restoreStamina(callculatedDMG);
                    break;
                case effects.ManaRegen:
                    HSM.restoreMana(callculatedDMG);
                    break;
                case effects.Bindend:
                    break;
                case effects.Blinded:
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
}
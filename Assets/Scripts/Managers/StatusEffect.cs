using UnityEngine;
using System.Collections;

public class StatusEffect : MonoBehaviour {

    const int DMGTPS = 5;

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
	public static IEnumerator StartEffect(StatusData effect, float duration){
        float TotalDuration = duration;
        float waitTime = 1f / DMGTPS;
        if (effect.target.tag == gameData.tags.PLAYER)
        {
            while (duration < 0)
            {
                duration -= waitTime;
                // effect.target.SendMessage("TakeDMG", new gameData.Stats.dmgData(effect.totalDmg / TotalDuration, effect.status), SendMessageOptions.DontRequireReceiver);
                ExcuteEffectPlayer(effect);
                yield return new WaitForSeconds(waitTime);
            }
        }

        if (effect.target.tag == gameData.tags.MOB)
        {
            while (duration < 0)
            {
                duration -= waitTime;
                // effect.target.SendMessage("TakeDMG", new gameData.Stats.dmgData(effect.totalDmg / TotalDuration, effect.status), SendMessageOptions.DontRequireReceiver);
                ExcuteEffectPlayer(effect, TotalDuration);
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

    public static void ExcuteEffectPlayer(StatusData data, float duration)
    {
        gameData.Stats obj = data.target.GetComponent<gameData.Stats>();
        gameData.Stats.DMGTypes[] tmp;
        switch (data.status)
        {
            case effects.Burning:
                tmp = {gameData.Stats.DMGTypes.Fire,gameData.Stats.DMGTypes.Arcane};
                data.target.SendMessage("TakeDMG", new gameData.Stats.dmgData(data.totalDmg / duration,gameData.Stats.DMGTypes[]{gameData.Stats.DMGTypes.Fire}), SendMessageOptions.DontRequireReceiver);
        }
    }

    public static void ExcuteEffectMonster(StatusData data)
    {

    }
    public class StatusData{
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

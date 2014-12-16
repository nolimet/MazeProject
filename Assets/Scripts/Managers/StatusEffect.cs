using UnityEngine;
using System.Collections;

public class StatusEffect : MonoBehaviour {

    const int DMGTPS = 5;

	public static IEnumerator StartEffect(StatusData effect, float duration){
        float TotalDuration = duration;
        float waitTime = 1f / DMGTPS;
        while (duration < 0)
        {
            duration -= waitTime;
            effect.target.SendMessage("TakeDMG", new gameData.Stats.dmgData(effect.totalDmg / TotalDuration, effect.status), SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public class StatusData{
        public gameData.Stats.DMGTypes[] status;
        public GameObject target;
        public float totalDmg;

        public StatusData(gameData.Stats.DMGTypes[] status, GameObject target, float totalDmg)
        {
            this.status = status;
            this.target = target;
            this.totalDmg = totalDmg;
        }
    }
}

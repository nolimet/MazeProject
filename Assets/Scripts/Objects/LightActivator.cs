using UnityEngine;
using System.Collections;
namespace Mechanismes
{
    public class LightActivator : BasicUse
    {
        bool activated;
        [SerializeField]
        LightData data = new LightData();
        protected override void UseObj()
        {
            if (!activated)
                StartCoroutine(LightLights());
        }

        IEnumerator LightLights()
        {
            activated = true;
            yield return new WaitForSeconds(data.initalDelay);
            foreach (Light l in data.lights)
            {
                StartCoroutine(lightSingle(l));
                yield return new WaitForSeconds(data.delayBetweenlights);
            }
            yield break;
        }

        IEnumerator lightSingle(Light l)
        {
            for (int i = 0; i < data.stepsPerLight; i++)
            {
                l.intensity += data.luminocity / data.stepsPerLight;
                yield return new WaitForSeconds(data.timePerlight / data.stepsPerLight);
            }
            yield break;
        }

        [System.Serializable]
        public class LightData
        {
            public float luminocity = 0, initalDelay, delayBetweenlights, timePerlight;
            public int stepsPerLight = 0;
            public Light[] lights;
        }
    }
}
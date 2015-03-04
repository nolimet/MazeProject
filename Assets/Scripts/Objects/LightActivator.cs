using UnityEngine;
using System.Collections;
namespace Mechanismes
{
    public class LightActivator : BasicUse
    {
        bool activated;
        [SerializeField]
        LightData data = new LightData();

        void Start()
        {
            foreach (Light l in data.lights)
            {
                l.intensity = 0;
                l.gameObject.GetComponent<ParticleSystem>().emissionRate = 0;
            }
        }
        protected override void UseObj()
        {
            if (!activated)
                StartCoroutine(LightLights());
        }

        IEnumerator LightLights()
        {
            activated = true;
            yield return new WaitForSeconds(data.initalDelay);
            int i = 0;
            foreach (Light l in data.lights)
            {
                i++;
                l.gameObject.GetComponent<ParticleSystem>().emissionRate = data.particleEmisionRate;
                StartCoroutine(lightSingle(l));
                if (i % data.lightAtSameTime == 0)
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
            public int stepsPerLight = 0, lightAtSameTime = 1, particleEmisionRate = 10;
            public Light[] lights;
        }
    }
}
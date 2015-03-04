using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class MagicLight : MonoBehaviour {

    private float maxIntensity;
    void Start()
    {
        GetComponent<Light>().enabled = false;
        maxIntensity = GetComponent<Light>().intensity;
        managers.EventManager.CastSpell +=EventManager_CastSpell;

    }

    private void EventManager_CastSpell(MagicSpells.SelfSpells SpellSelf)
    {
        if(SpellSelf == MagicSpells.SelfSpells.magicLight)
            StartCoroutine(casting());
    }

    IEnumerator casting()
    {
        HSMManager.castingContinuesSpell = true;
        GetComponent<Light>().enabled = true;

        for (int i = 0; i < 15;i++ )
        {
            GetComponent<Light>().intensity = (maxIntensity / 15) * i;
            yield return new WaitForEndOfFrame();
        }
            
        while (Input.GetButton(Axis.CastSpellSelf) && gameData.HSM.CastSpell(3f*Time.deltaTime))
        {
            yield return new WaitForEndOfFrame();
        }

        for (int i = 15; i > 0; i--)
        {
            GetComponent<Light>().intensity = (maxIntensity / 15) * i;
            yield return new WaitForEndOfFrame();
        }

        GetComponent<Light>().enabled = false;
        HSMManager.castingContinuesSpell = false;
    }
}

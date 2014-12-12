using UnityEngine;
using System.Collections;
namespace Mechanismes
{
    public class SpikeTrap : MonoBehaviour
    {

        [SerializeField]
        Transform[] Spikes = new Transform[0];
        [SerializeField]
        float spikeLenght = 2.9f;
        [SerializeField]
        float damage;
        [SerializeField]
        gameData.Stats.DMGTypes[] dmgTypes;

        int l;
        void Start()
        {
            l = Spikes.Length;
            print(transform.forward);
        }
        void Update()
        {
            RaycastHit hit;
            for (int i = 0; i < l; i++)
            {
                if (Physics.Raycast(Spikes[i].position, Spikes[i].forward, out hit, spikeLenght))
                {
                    hit.collider.transform.SendMessage("TakeDMG", new gameData.Stats.dmgData(damage, dmgTypes), SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
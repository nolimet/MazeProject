using UnityEngine;
using System.Collections;
namespace monsters{
    public class EHSM_Manager : MonoBehaviour
    {
        [SerializeField]
        int maxHealth = 100;
        float health = 100f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        
        void TakeDMG(float dmg)
        {
            health -= dmg;
            if(health<=0)
                renderer.material.color += Color.red;
            print(health);
        }
    }
}

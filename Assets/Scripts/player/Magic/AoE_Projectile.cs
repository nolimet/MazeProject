using UnityEngine;
using System.Collections;

public class AoE_Projectile : MonoBehaviour {
    //example AoE
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 7f);
    }

    void OnCollisionEnter(Collision col)
    {
        Ray bag;
        RaycastHit rayHit;
        Collider[] hits = Physics.OverlapSphere(transform.position-transform.forward,10);
        foreach (Collider hit in hits)
        {
            
            
            if (hit.collider.tag == gameData.tags.mob || hit.collider.tag == gameData.tags.player)
            {
                print("bang");
                bag = new Ray(transform.position, hit.transform.position-transform.position);
                
                if (Physics.Raycast(bag,out rayHit,20f))
                    Debug.DrawRay(transform.position, bag.direction, Color.blue, 2f);
                    if(rayHit.collider.tag == hit.collider.tag)
                        hit.SendMessage("TakeDMG", 20, SendMessageOptions.DontRequireReceiver);
            }
        }
        particleSystem.emissionRate = 0;
        particleSystem.startLifetime = 5;
        particleSystem.Emit(400);
        
        Destroy(gameObject, 6f);
        Destroy(this);
    }
}

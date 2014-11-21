using UnityEngine;
using System.Collections;

public class AoE_Projectile : MonoBehaviour {
    //example AoE
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * 20f);
    }

    void OnCollisionEnter(Collision col)
    {
        Explode();
    }

    void Explode()
    {
        GetComponent<SphereCollider>().enabled = false;
        Ray ray;
        RaycastHit rayHit;
        Collider[] hits = Physics.OverlapSphere(transform.position - transform.forward, 5);
        foreach (Collider hit in hits)
        {


            if (hit.collider.tag == gameData.tags.mob || hit.collider.tag == gameData.tags.player)
            {
                ray = new Ray(transform.position, hit.transform.position - transform.position);

                if (Physics.Raycast(ray, out rayHit, 20f))
                    if (rayHit.collider.tag == hit.collider.tag)
                        hit.SendMessage("TakeDMG", 20, SendMessageOptions.DontRequireReceiver);
            }
        }
        particleSystem.emissionRate = 0;
        particleSystem.startSpeed = 3;
        particleSystem.Emit(400);

        Destroy(gameObject, 2f);
        Destroy(this);
    }
}

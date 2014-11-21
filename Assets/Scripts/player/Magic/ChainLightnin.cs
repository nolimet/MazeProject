using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChainLightnin : MonoBehaviour
{
    public int MaxChain = 2;
    public float Radius;
    void Lightnin()
    {
        GetComponent<SphereCollider>().enabled = false;
        Ray ray;
        RaycastHit rayHit;
        Collider[] hits;
        Transform cTarget = null;
        Transform cObj = transform;
        List<Transform> hasHit = new List<Transform>();
        float closest = Radius + 0.1f;
       
        for (int i = 0; i < MaxChain; i++)
        {

            hits = Physics.OverlapSphere(transform.position - transform.forward, Radius);
            if (hits.Length == 0)
                return;

            foreach (Collider hit in hits)
            {
                if (hit.collider.tag == gameData.tags.mob || hit.collider.tag == gameData.tags.player)
                {
                    ray = new Ray(transform.position, hit.transform.position - transform.position);

                    if (Physics.Raycast(ray, out rayHit, Radius) && Vector3.Distance(hit.transform.position, cObj.transform.position) < closest && hasHit.Contains(hit.transform) && cObj != cTarget && rayHit.collider.tag == hit.collider.tag )
                            cTarget = cObj;
                }
            }
            hasHit.Add(cTarget);
            //endforloop
        }

        foreach (Transform t in hasHit)
        {
            t.gameObject.SendMessage("TakeDMG", 20, SendMessageOptions.DontRequireReceiver);
        }
    }
}

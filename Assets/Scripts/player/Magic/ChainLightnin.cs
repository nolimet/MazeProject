using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChainLightnin : MonoBehaviour
{
    public int MaxChain = 2;
    public float Radius;
    public List<Transform> hasHit;
    public gameData.Stats.DMGTypes[] damageTypes;
    public float Damage;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 12f);
    }

    void OnCollisionEnter(Collision col)
    {
        Lightnin();
    }

    void Lightnin()
    {
        GetComponent<SphereCollider>().enabled = false;
        Ray ray;
        RaycastHit rayHit;
        Collider[] hits;
        Transform cTarget = null;
        Transform cObj = transform;
        hasHit = new List<Transform>();
        float closest;


        particleSystem.emissionRate = 0f;
        Destroy(gameObject, 1f);
        Destroy(this, 0.1f);


        for (int i = 0; i < MaxChain; i++)
        {
            closest = Radius + 0.1f;

            hits = Physics.OverlapSphere(transform.position - transform.forward, Radius);

            foreach (Collider hit in hits)
            {
                if (hit.collider.tag == gameData.tags.MOB || hit.collider.tag == gameData.tags.PLAYER)
                {
                    ray = new Ray(transform.position, hit.transform.position - transform.position);

                    if (Physics.Raycast(ray, out rayHit, Radius) && Vector3.Distance(hit.collider.transform.position, cObj.transform.position) < closest && !hasHit.Contains(hit.transform) && hit.collider.transform != transform)
                        cTarget = hit.collider.transform;
                }
            }
            if (cTarget == null)
                return;

            hasHit.Add(cTarget);
            Debug.DrawLine(cTarget.position, cObj.position, Color.cyan, 4f);
            cObj = cTarget;
            cTarget = null;
        }

        foreach (Transform t in hasHit)
        {
            t.gameObject.SendMessage("TakeDMG", new gameData.Stats.dmgData(Damage,damageTypes), SendMessageOptions.DontRequireReceiver);
        }

        
    }
}
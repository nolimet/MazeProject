using UnityEngine;
using System.Collections;

public class AoE_Projectile : MonoBehaviour
{
    //example AoE

    public gameData.Stats.DMGTypes[] damageTypes;
    public float Damage;
    public float radius;

    void Start()
    {
        Destroy(this.gameObject, 20f);
    }
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
        Collider[] hits = Physics.OverlapSphere(transform.position - transform.forward, radius);
        foreach (Collider hit in hits)
        {


            if (hit.collider.tag == gameData.tags.MOB || hit.collider.tag == gameData.tags.PLAYER)
            {
                ray = new Ray(transform.position, hit.transform.position - transform.position);

                if (Physics.Raycast(ray, out rayHit, radius * 2f))
                    if (rayHit.collider.tag == hit.collider.tag)
                        hit.collider.transform.SendMessage("TakeDMG", new gameData.Stats.dmgData(Damage, damageTypes), SendMessageOptions.DontRequireReceiver);
            }
        }
        particleSystem.emissionRate = 0;
        particleSystem.startSpeed = 3;
        particleSystem.Emit(400);
        particleSystem.gravityModifier = 1f;
        Destroy(gameObject, 2f);
        Destroy(this);
    }
}

using UnityEngine;
using System.Collections;

public class AoE_Projectile : MonoBehaviour
{
    //example AoE

   // public gameData.Stats.DMGTypes[] damageTypes;
    public managers.StatusEffect.effects effectType = managers.StatusEffect.effects.Burning;
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


            if (hit.GetComponent<Collider>().tag == gameData.tags.MOB || hit.GetComponent<Collider>().tag == gameData.tags.PLAYER)
            {
                ray = new Ray(transform.position, hit.transform.position - transform.position);

                if (Physics.Raycast(ray, out rayHit, radius * 2f))
                    if (rayHit.collider.tag == hit.GetComponent<Collider>().tag)
                        // hit.collider.transform.SendMessage("TakeDMG", new gameData.Stats.dmgData(Damage, damageTypes), SendMessageOptions.DontRequireReceiver);
                        managers.StatusEffect.StartEffect(new managers.StatusEffect.StatusData(effectType, hit.GetComponent<Collider>().gameObject, Damage), 3f);
            }
        }
        GetComponent<ParticleSystem>().emissionRate = 0;
        GetComponent<ParticleSystem>().startSpeed = 3;
        GetComponent<ParticleSystem>().Emit(400);
        GetComponent<ParticleSystem>().gravityModifier = 0.5f;
        Destroy(gameObject, 2f);
        Destroy(this);
    }
}

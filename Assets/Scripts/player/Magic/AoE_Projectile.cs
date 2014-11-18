using UnityEngine;
using System.Collections;

public class AoE_Projectile : MonoBehaviour {

    void Update()
    {
        transform.Translate(transform.forward);
    }

    void OnCollisionEnter(Collision col)
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 10f, Vector3.zero);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag == gameData.tags.mob || hit.collider.tag == gameData.tags.player)
            {
                if (Physics.Raycast(new Ray(transform.position, transform.position - hit.point)))
                    hit.collider.gameObject.SendMessage("TakeDMG", 20, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}

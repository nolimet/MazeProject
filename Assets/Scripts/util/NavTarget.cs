using UnityEngine;
using System.Collections;

public class NavTarget : MonoBehaviour {


    [SerializeField]
    private Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

	void Update () {
        if (agent.destination != target.position && Vector3.Distance(target.position, transform.position) < 15f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, target.position - transform.position, out hit, 100))
            {
                print(hit.collider.gameObject.tag);

                if (hit.transform.gameObject.tag == "Player")
                {
                    agent.SetDestination(target.position);
                    print("boom");
                }
            }
        }
        Debug.DrawRay(transform.position, target.position-transform.position, Color.red, 1f);
	}
}

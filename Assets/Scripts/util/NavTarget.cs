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
            Physics.RaycastAll(new Ray(transform.position, target.position));
            agent.SetDestination(target.position);
	}
}

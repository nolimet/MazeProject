using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public enum Dir
    {
        up, right, left, down, none
    }

    private Dir direction;
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(Vector3.back * Input.GetAxis("Horizontal") * 100f);
        GetComponent<Rigidbody>().AddForce(Vector3.right * Input.GetAxis("Vertical") * 100f);

        transform.rotation = Quaternion.Euler(new Vector3(-25f * Input.GetAxis("Horizontal"), 0, 0));
	}
}

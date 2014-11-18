using UnityEngine;
using System.Collections;

public class SetCamInHSM : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameData.HSM.Camera = transform;
        Destroy(this);
	}
}

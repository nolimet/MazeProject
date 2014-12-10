using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

    public bool[] lockedAxis = new bool[4];
    
	void Update () {
        if (HSMManager.instance == null)
            return;
        Quaternion newRot;
        transform.LookAt(HSMManager.instance.transform.position);
        
        newRot = transform.rotation;
        Vector3 tmpRot = newRot.eulerAngles;
        if (lockedAxis[0])
            tmpRot.x = 0;
        if (lockedAxis[1])
            tmpRot.y = 0;
        if (lockedAxis[2])
            tmpRot.z = 0;
        if (lockedAxis[3])
            tmpRot.y -= 180f;
       // print(tmpRot);
        newRot = Quaternion.Euler(tmpRot);
        transform.rotation = newRot;

	}
}

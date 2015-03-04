using UnityEngine;
using System.Collections;

public class colourPingPong : MonoBehaviour {

    [SerializeField]
    float pingpongTime;
    [SerializeField]
    float colourShiftAmount;
    [SerializeField]
    Color colour;

	void Update () {
        GetComponent<Renderer>().material.color = colour * ((1 - colourShiftAmount) + (colourShiftAmount * Mathf.PingPong(Time.time, pingpongTime)));
        
	}
}

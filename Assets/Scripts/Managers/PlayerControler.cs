using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    CharacterController control;
    const float gravity = 20f;
    void Start()
    {
        control = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 move = new Vector3();
        move.x += Input.GetAxis(Axis.Horizontal)/100f;
        move.z += Input.GetAxis(Axis.Vertical)/100f;
        move = transform.TransformDirection(move);
        move.y -= gravity;
        if (Input.GetButton(Axis.Sprint))
        {
            move = move * 10f;
        }
        control.Move(move);
    }
}

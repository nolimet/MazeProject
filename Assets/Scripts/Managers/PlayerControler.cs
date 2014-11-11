using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    CharacterController control;
    const float gravity = 2f;
    const float JumpSpeed = 80.0f;
    const float Speed = 6.00f;
    void Start()
    {
        control = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 move = new Vector3();
        if (control.isGrounded)
        {
            move.x += Input.GetAxis(Axis.Horizontal);
            move.z += Input.GetAxis(Axis.Vertical);
            move = transform.TransformDirection(move);
            move *= Speed;
            if (Input.GetButton(Axis.Sprint))
            {
                move = move * 2f;
            }

            if (Input.GetButton(Axis.Jump))
            {
                move.y += JumpSpeed;
                print("Jump");
            }
        }

        move.y -= gravity ;
        control.Move(move*Time.deltaTime);
    }
}

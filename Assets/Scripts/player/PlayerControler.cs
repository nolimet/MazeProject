﻿using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    CharacterController control;

    const float gravity = 20f;
    const float Speed = 4.00f;
    void Start()
    {
        control = GetComponent<CharacterController>();
    }
    void Update()
    {
        playerMove();
        playerActions();
    }

    void playerMove()
    {
        if (!managers.MenuManager.paused)
        {
            Vector3 move = new Vector3();
            if (control.isGrounded)
            {
                move.x += Input.GetAxis(Axis.Horizontal);
                move.z += Input.GetAxis(Axis.Vertical);
                move = transform.TransformDirection(move);
                move *= Speed;
                if (Input.GetButton(Axis.Sprint) && gameData.HSM.Stamina > 1)
                {
                    move = move * 2f;
                }

                /*if (Input.GetButton(Axis.Jump))
                {
                    move.y += JumpSpeed;
                    print("Jump");
                }*/
            }

            move.y -= gravity;
            control.Move(move * Time.deltaTime);
        }
    }

    void playerActions()
    {
        if(Input.GetButton(Axis.Interact))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3f))
                hit.collider.transform.SendMessage("UseObj",SendMessageOptions.DontRequireReceiver);
            }
    }
}
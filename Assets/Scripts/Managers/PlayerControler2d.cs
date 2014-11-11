using UnityEngine;
using System.Collections;

public class PlayerControler2d : MonoBehaviour
{
    CharacterController control;
    const float gravity = 2f;
    const float JumpSpeed = 5120.0f;
    const float Speed = 320.00f;
    [SerializeField]
    private float sprintMod = 1.4f;
    [SerializeField]
    bool isGrounded;
    [SerializeField]
    bool doubleJumped;

    void FixedUpdate()
    {
         RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,Mathf.Infinity);
         if (hit.collider != null)
         {
             float distance = Mathf.Abs(hit.point.y - transform.position.y);
             if (distance < 0.6f)
                 isGrounded = true;
             else
                 isGrounded = false;
         }
    }
       
    void Update()
    {
        Vector3 move = new Vector2();

        if (isGrounded)
        {
            doubleJumped = false;

            move.x += Input.GetAxis(Axis.Horizontal);

            move *= Speed;
            if (Input.GetButton(Axis.Sprint))
            {
                move = move * sprintMod;
            }

            if (Input.GetButton(Axis.Jump))
                move.y += JumpSpeed;
        }
        else
        {
            if (!doubleJumped && Input.GetButtonDown(Axis.Jump))
            {
                move.y += JumpSpeed;
                doubleJumped = true;
            }
        }

        if (Input.GetAxis(Axis.Horizontal) == 0 || Input.GetButton(Axis.Jump))
            if(isGrounded)
                rigidbody2D.drag = 5;
            else
                rigidbody2D.drag = 0;
        else
                rigidbody2D.drag = 0;
        //move.y -= gravity ;
        rigidbody2D.AddForce(move*Time.deltaTime);
    }
}

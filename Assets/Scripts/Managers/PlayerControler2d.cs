using UnityEngine;
using System.Collections;

public class PlayerControler2d : MonoBehaviour
{
    CharacterController control;
    const float gravity = 2f;
    const float JumpSpeed = 80.0f;
    const float Speed = 32.00f;
    [SerializeField]
    private float sprintMod = 1.4f;
    bool isGrounded;

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
        Vector3 move = new Vector2();
        if (isGrounded)
        {
            move.x += Input.GetAxis(Axis.Horizontal);
           
            //move.z += Input.GetAxis(Axis.Vertical);
           // move = transform.TransformDirection(move);
            move *= Speed;
            if (Input.GetButton(Axis.Sprint))
            {
                move = move * sprintMod;
            }

            if (Input.GetButton(Axis.Jump))
            {
                move.y += JumpSpeed;
                print("Jump");
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
        rigidbody2D.AddForce(move);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class MM : MonoBehaviour
{
    Animator anim;

    bool isWalking = false;
    const float WALK_SPEED = .25f;
    public float jumpForce = 2.0f;
    public Vector3 jump;
    public float distToGround;
    Rigidbody rb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        distToGround = collider.bounds.extents.y;
    }
    void Update()
    {
        Walking();
        Turning();
        Move();
        Jump();
    }

    void Turning()
    {
        anim.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }
    void Walking()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isWalking = !isWalking;
            anim.SetBool("Walk", isWalking);
        }


    }
    void Move()
    {
        if (anim.GetBool("Walk"))
        {
            anim.SetFloat("MoveZ", Mathf.Clamp(Input.GetAxis("MoveZ"), -WALK_SPEED, WALK_SPEED));
            anim.SetFloat("MoveX", Mathf.Clamp(Input.GetAxis("MoveX"), -WALK_SPEED, WALK_SPEED));
        }
        else
        {
            anim.SetFloat("MoveZ", Input.GetAxis("MoveZ"));
            anim.SetFloat("MoveX", Input.GetAxis("MoveX"));
        }

    }
    bool isGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            anim.SetTrigger("Jump");
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
}

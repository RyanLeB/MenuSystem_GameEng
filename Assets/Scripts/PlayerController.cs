using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator anim;
    Vector2 movement;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");


    }

    void FixedUpdate()
    {
        HandleMove();
        HandleAnim();

    }

    public void HandleMove()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

    public void HandleAnim()
    {
         
        
        if (movement != Vector2.zero) 
        {
        anim.SetFloat("MovementX", movement.x);
        anim.SetFloat("MovementY", movement.y);
        anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);    
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody2D rb;
    private float moveInput;
    public Transform groundCheck;
    public float jumpforce = 10f;
    private float groundCheckradius = 0.2f;
    public LayerMask groundlayer;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckradius,groundlayer);
        Jump();
    }
    private void FixedUpdate()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        
    }
    private void Jump()
    {
        if (isGrounded == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.up * jumpforce;
            }
        }
    }
}

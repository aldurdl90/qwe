using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float h;
    public float jumpForce;
    public float speed; 
    Rigidbody2D rb;
    bool isGrounded = true; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h= Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded )
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    void FixedUpdate()
    {
        //rb.velocity = new Vector2(h * speed, rb.velocity.y);
        
        rb.AddForce(new Vector2(h * speed, 0), ForceMode2D.Force);
        if (rb.velocity.x > 10f) // Limit the maximum speed
        {
            rb.velocity = new Vector2(5f, rb.velocity.y);
        }
        else if (rb.velocity.x < -10f) // Limit the minimum speed
        {
            rb.velocity = new Vector2(-5f, rb.velocity.y);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Monster"))
        {
           
        }
    }
}

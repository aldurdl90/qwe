using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float h;
    public float jumpForce;
    public float speed;
    public float maxSpeed;
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
        rb.AddForce(new Vector2(h * speed, 0), ForceMode2D.Force);




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

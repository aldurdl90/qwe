using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h;
    public float jumpForce;
    public float speed; 
    Rigidbody2D rb;
 
    SpriteRenderer spriteRenderer;
    bool isGrounded = true; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (Input.GetButtonUp("Horizontal")) //좌우 이동후 키보드에서 손을 떄면 좌우 이동 멈춤
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }

        if (Input.GetAxisRaw("Horizontal") > 0) //좌우이동 애니메이션
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }


      
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        
       



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EditorOnly"))
        {
            Debug.Log("재시작");
           rb.transform.position = new Vector2(-4, 1); // 플레이어 위치를 초기화
        }
    }
}

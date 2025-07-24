using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h;
    public float jumpForce;
    public float speed; 
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider2D; // 플레이어의 캡슐 콜라이더
    public LayerMask groundLayer; // 바닥 레이어를 지정하기 위한 변수
    public float rayLength = 1f; // 바닥을 감지하기 위한 레이의 길이
    SpriteRenderer spriteRenderer;
    bool isGrounded = true; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        h= Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftAlt)&& isGrounded )
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
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

        Debug.DrawRay(rb.position ,Vector3.down, new Color(0, 1, 1));
        RaycastHit2D hit = Physics2D.Raycast

         (rb.position, Vector2.down, rayLength, groundLayer);
        if (hit.collider != null && rb.velocity.y == 0) // 바닥이 있으면
        {
            isGrounded = true; // 플레이어가 바닥에 닿아있음
        }
        else
        {
            isGrounded = false; // 바닥에 닿아있지 않음
        }

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        
       



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

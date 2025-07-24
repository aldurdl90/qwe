using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h;
    public float jumpForce;
    public float speed; 
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider2D; // �÷��̾��� ĸ�� �ݶ��̴�
    public LayerMask groundLayer; // �ٴ� ���̾ �����ϱ� ���� ����
    public float rayLength = 1f; // �ٴ��� �����ϱ� ���� ������ ����
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


        if (Input.GetButtonUp("Horizontal")) //�¿� �̵��� Ű���忡�� ���� ���� �¿� �̵� ����
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }

        if (Input.GetAxisRaw("Horizontal") > 0) //�¿��̵� �ִϸ��̼�
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
        if (hit.collider != null && rb.velocity.y == 0) // �ٴ��� ������
        {
            isGrounded = true; // �÷��̾ �ٴڿ� �������
        }
        else
        {
            isGrounded = false; // �ٴڿ� ������� ����
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
            Debug.Log("�����");
           rb.transform.position = new Vector2(-4, 1); // �÷��̾� ��ġ�� �ʱ�ȭ
        }
    }
}

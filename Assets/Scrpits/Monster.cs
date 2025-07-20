using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public int randommove;
    public LayerMask playerLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        MonsterAI(); 
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        rb.velocity = new Vector2(randommove*2, rb.velocity.y); // ���� �̵� �ӵ� ����
       

        float direction = Mathf.Sign(randommove);
        Vector2 rayOrigin = rb.position + new Vector2(0.6f * direction, 0f);
        Debug.DrawRay(rayOrigin, Vector3.down, new Color(0, 1, 1));
        RaycastHit2D hit = Physics2D.Raycast

         (rayOrigin, Vector2.down, 1f );
         
        if (hit.collider == null) // �ٴ��� ������ ������ �ٲ�
        {
            randommove *= -1;
            rb.velocity = new Vector2(randommove, rb.velocity.y);
           
        }
        else // �ٴ��� ������ �̵�
        {
             rb.velocity = new Vector2(randommove, rb.velocity.y);
        }

        if (rb.velocity.x > 0) // ���Ͱ� �������� �ٶ󺸰� ��
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x < 0) // ���Ͱ� ������ �ٶ󺸰� ��
        {
            spriteRenderer.flipX = false;
        }
    }


    private void MonsterAI()
    {
        randommove = Random.Range(-1, 2);
        Invoke("MonsterAI", 1.5f); // 2�ʸ��� ���� �̵� ���� ����
    }


    private void Update()
    {

        
        Collider2D playerCol = Physics2D.OverlapCircle(transform.position, 5f, playerLayer); // ���� �ֺ��� �ִ� �ݶ��̴���
        if(playerCol != null )
        {
            ChasePlayer();
            Debug.Log("���Ͱ� �÷��̾ �����մϴ�.");
        }


       




    }  

    private void ChasePlayer()
    {





    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // ���� ��
        Gizmos.DrawWireSphere(transform.position,5f); // �߽ɰ� ������
    }
}



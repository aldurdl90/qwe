using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Monster;

public class Monster : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public Player palyer; // �÷��̾� ������Ʈ�� �����ϱ� ���� ����
    public int randommove;
    public LayerMask playerLayer;
    float speed = 2f; // ���� �̵� �ӵ�
    bool isChasing = false; 




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        MonsterAI(); 
    }


    // Update is called once per frame
    public void FixedUpdate()
    {
        if(isChasing) // �÷��̾ �������� ���� �� ���� �̵�
        {
            IsCasesing(); // �÷��̾ �����ϴ� ���·� ����
        }
        else // �÷��̾ ������ �� ���� �̵�
        {
            Idle();
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

    public void Idle()
    {
        float direction = Mathf.Sign(randommove);
        Vector2 rayOrigin = rb.position + new Vector2(0.6f * direction, 0f);
        Debug.DrawRay(rayOrigin, Vector3.down, new Color(0, 1, 1));
        RaycastHit2D hit = Physics2D.Raycast

         (rayOrigin, Vector2.down, 1f);

        if (hit.collider == null) // �ٴ��� ������ ������ �ٲ�
        {
            randommove *= -1;
            rb.velocity = new Vector2(randommove, rb.velocity.y);

        }
        else // �ٴ��� ������ �̵�
        {
            rb.velocity = new Vector2(randommove, rb.velocity.y);
        }
    }


    public void IsCasesing()
    {
        Debug.Log("IsCasesing");
        Vector2 dir = new Vector2(palyer.transform.position.x - transform.position.x, 0f).normalized;
        Vector2 rayOrigin = rb.position + new Vector2(0.75f * dir.x, 0f);
        Debug.DrawRay(rayOrigin, Vector3.down, new Color(0, 1, 1));
        RaycastHit2D hit = Physics2D.Raycast

         (rayOrigin, Vector2.down, 1f);
 

        if (hit.collider == null) // �ٴ��� ������ ������ �ٲ�
        {
            rb.velocity = new Vector2( 0, rb.velocity.y);
            isChasing = false; // �ٴ��� ������ ���� ���� ����
        }
        else
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y); // �÷��̾� �������� �̵�
        }

    }

    public void MonsterAI()
    {
        randommove = Random.Range(-1, 2);
        rb.velocity = new Vector2(randommove * speed, rb.velocity.y); 
        Invoke("MonsterAI", 1.5f); // 2�ʸ��� ���� �̵� ���� ����
        
    }


    private void Update()
    {      
        Collider2D playerCol = Physics2D.OverlapCircle(transform.position, 5f, playerLayer); // ���� �ֺ��� �ִ� �ݶ��̴���
        if(playerCol != null )
        {
            isChasing = true; // �÷��̾ ���� �ֺ��� ������ ���� ���·� ����

        }
        else
        {
            isChasing = false; // �÷��̾ ���� �ֺ��� ������ ���� ���� ����
        }

    }  

   

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // ���� ��
        Gizmos.DrawWireSphere(transform.position,5f); // �߽ɰ� ������
    }
}



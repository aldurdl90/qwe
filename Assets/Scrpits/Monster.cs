using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Monster;

public class Monster : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public Player palyer; // 플레이어 오브젝트를 연결하기 위한 변수
    public int randommove;
    public LayerMask playerLayer;
    float speed = 2f; // 몬스터 이동 속도
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
        if(isChasing) // 플레이어를 추적하지 않을 때 몬스터 이동
        {
            IsCasesing(); // 플레이어를 추적하는 상태로 변경
        }
        else // 플레이어를 추적할 때 몬스터 이동
        {
            Idle();
        }

        if (rb.velocity.x > 0) // 몬스터가 오른쪽을 바라보게 함
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x < 0) // 몬스터가 왼쪽을 바라보게 함
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

        if (hit.collider == null) // 바닥이 없으면 방향을 바꿈
        {
            randommove *= -1;
            rb.velocity = new Vector2(randommove, rb.velocity.y);

        }
        else // 바닥이 있으면 이동
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
 

        if (hit.collider == null) // 바닥이 없으면 방향을 바꿈
        {
            rb.velocity = new Vector2( 0, rb.velocity.y);
            isChasing = false; // 바닥이 없으면 추적 상태 해제
        }
        else
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y); // 플레이어 방향으로 이동
        }

    }

    public void MonsterAI()
    {
        randommove = Random.Range(-1, 2);
        rb.velocity = new Vector2(randommove * speed, rb.velocity.y); 
        Invoke("MonsterAI", 1.5f); // 2초마다 몬스터 이동 방향 변경
        
    }


    private void Update()
    {      
        Collider2D playerCol = Physics2D.OverlapCircle(transform.position, 5f, playerLayer); // 몬스터 주변에 있는 콜라이더를
        if(playerCol != null )
        {
            isChasing = true; // 플레이어가 몬스터 주변에 있으면 추적 상태로 변경

        }
        else
        {
            isChasing = false; // 플레이어가 몬스터 주변에 없으면 추적 상태 해제
        }

    }  

   

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // 원의 색
        Gizmos.DrawWireSphere(transform.position,5f); // 중심과 반지름
    }
}



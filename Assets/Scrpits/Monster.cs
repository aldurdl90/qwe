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

        rb.velocity = new Vector2(randommove*2, rb.velocity.y); // 몬스터 이동 속도 설정
       

        float direction = Mathf.Sign(randommove);
        Vector2 rayOrigin = rb.position + new Vector2(0.6f * direction, 0f);
        Debug.DrawRay(rayOrigin, Vector3.down, new Color(0, 1, 1));
        RaycastHit2D hit = Physics2D.Raycast

         (rayOrigin, Vector2.down, 1f );
         
        if (hit.collider == null) // 바닥이 없으면 방향을 바꿈
        {
            randommove *= -1;
            rb.velocity = new Vector2(randommove, rb.velocity.y);
           
        }
        else // 바닥이 있으면 이동
        {
             rb.velocity = new Vector2(randommove, rb.velocity.y);
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


    private void MonsterAI()
    {
        randommove = Random.Range(-1, 2);
        Invoke("MonsterAI", 1.5f); // 2초마다 몬스터 이동 방향 변경
    }


    private void Update()
    {

        
        Collider2D playerCol = Physics2D.OverlapCircle(transform.position, 5f, playerLayer); // 몬스터 주변에 있는 콜라이더를
        if(playerCol != null )
        {
            ChasePlayer();
            Debug.Log("몬스터가 플레이어를 추적합니다.");
        }


       




    }  

    private void ChasePlayer()
    {





    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // 원의 색
        Gizmos.DrawWireSphere(transform.position,5f); // 중심과 반지름
    }
}



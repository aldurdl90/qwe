using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public GameManager gameManager; // 게임 매니저 스크립트 참조
    public Image healthBar; // 체력바 UI 이미지
    public void Start()
    {
        hp = maxHp; // 플레이어의 체력을 최대 체력으로 초기화
    }
    public void TakeDamage(float damage)
    {
        hp -= damage; // 플레이어가 피해를 입을 때 체력 감소
     
    }


    private void Update()
    {
        healthBar.fillAmount = hp / maxHp; // 체력바의 채움 비율을 계산

        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        IsAttted();
        
    }

    public IEnumerator IsAttted()
    {
        LayerMask playerAttacked = LayerMask.GetMask("isAttacked");
        yield return new WaitForSeconds(2f);
        LayerMask playerLayer = LayerMask.GetMask("Player");


    }


}











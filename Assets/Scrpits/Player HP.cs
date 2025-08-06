using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public GameManager gameManager; // ���� �Ŵ��� ��ũ��Ʈ ����
    public Image healthBar; // ü�¹� UI �̹���
    public void Start()
    {
        hp = maxHp; // �÷��̾��� ü���� �ִ� ü������ �ʱ�ȭ
    }
    public void TakeDamage(float damage)
    {
        hp -= damage; // �÷��̾ ���ظ� ���� �� ü�� ����
     
    }


    private void Update()
    {
        healthBar.fillAmount = hp / maxHp; // ü�¹��� ä�� ������ ���

        
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











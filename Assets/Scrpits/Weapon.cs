using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    public GameManager gameManager; 
    public Monster monster; 
    public Player player; // �÷��̾� ��ũ��Ʈ ����
    SpriteRenderer spriteRenderer;
    Animator animator;
    private float nextAttackTime = 0f;
    public float attackCooldown = 0.5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        animator = GetComponent<Animator>();

    }

    public void StartAttack()
    {
        boxCollider2D.enabled = true;      
        Debug.Log("����");
    }

    public void EndAttack()
    {
        boxCollider2D.enabled = false;
       
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attacking");
            nextAttackTime = Time.time + attackCooldown;
        }
       
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            monster.Hp--;
            Debug.Log("���� ���� ü�� : "+ monster.Hp);
            monster.OnAttacked(); // ���Ͱ� ���ݴ����� �� ȣ��Ǵ� �޼���
        }
    }

}

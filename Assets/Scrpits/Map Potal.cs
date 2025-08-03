using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ���� �����ϱ� ���� ���ӽ����̽�

public class MapPotal : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E)) // E Ű�� ������ ��
            {
                SceneManager.LoadScene(1); // "GameOver" ������ ��ȯ
            }
        }
    }

}

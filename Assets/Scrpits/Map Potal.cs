using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬을 관리하기 위한 네임스페이스

public class MapPotal : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E)) // E 키를 눌렀을 때
            {
                SceneManager.LoadScene(1); // "GameOver" 씬으로 전환
            }
        }
    }

}

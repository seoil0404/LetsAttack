using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 특정 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Player"))
        {
            // 이 오브젝트를 삭제
            Destroy(gameObject);
        }
    }
}

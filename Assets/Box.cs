using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� Ư�� �±׸� ������ �ִ��� Ȯ��
        if (collision.gameObject.CompareTag("Player"))
        {
            // �� ������Ʈ�� ����
            Destroy(gameObject);
        }
    }
}

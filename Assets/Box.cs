using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� Ư�� �±׸� ������ �ִ��� Ȯ��
        if (collision.gameObject.name == "Ship")
        {
           
                // �Լ� �迭 ����
                System.Action[] functions = { FunctionOne, FunctionTwo, FunctionThree };

                // �������� �Լ� ���� �� ����
                int randomIndex = Random.Range(0, functions.Length);
                functions[randomIndex]();
            

            void FunctionOne()
            {
                GameObject.Find("Ship").GetComponent<Bomb_Manager>().Skill1();
            }

            void FunctionTwo()
            {
                GameObject.Find("Ship").GetComponent<Bomb_Manager>().Skill2();
            }

            void FunctionThree()
            {
                GameObject.Find("Ship").GetComponent<Bomb_Manager>().Skill3();
            }
            // �� ������Ʈ�� ����
            Destroy(gameObject);
        }
    }
}

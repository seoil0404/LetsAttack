using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Bomb_Manager
{
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� Ư�� �±׸� ������ �ִ��� Ȯ��
        if (collision.gameObject.CompareTag("Player"))
        {
           
                // �Լ� �迭 ����
                System.Action[] functions = { FunctionOne, FunctionTwo, FunctionThree };

                // �������� �Լ� ���� �� ����
                int randomIndex = Random.Range(0, functions.Length);
                functions[randomIndex]();
            

            void FunctionOne()
            {
                Skill1();
            }

            void FunctionTwo()
            {
                Skill2();
            }

            void FunctionThree()
            {
                Skill3();
            }
            // �� ������Ʈ�� ����
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Bomb_Manager
{
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 특정 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Player"))
        {
           
                // 함수 배열 생성
                System.Action[] functions = { FunctionOne, FunctionTwo, FunctionThree };

                // 랜덤으로 함수 선택 및 실행
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
            // 이 오브젝트를 삭제
            Destroy(gameObject);
        }
    }
}

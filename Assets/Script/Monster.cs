using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// NavMeshAgent 를 사용하기 위해 추가
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    public Transform target;             // 타겟(플레이어) Transform
    public float attackRange = 4f;       // 공격 시작 거리
    public float attackDelay = 1f;
    public float chaseRange = 10f;       // 추적 시작 거리// 공격 딜레이 시간
    private float lastAttackTime;        // 마지막으로 공격한 시간 기록

    private NavMeshAgent agent;          // NavMeshAgent 컴포넌트

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackRange; // 적이 공격 범위 내에서 멈추도록 설정
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
       // Debug.Log("Distance to Target: " + distanceToTarget); // 디버깅용 로그 추가

        if (distanceToTarget <= attackRange)
        {
          //  Debug.Log("Within attack range, stopping agent"); // 공격 범위 내에 들어왔음을 로그로 표시
            Attack();
        }
        else if (distanceToTarget <= chaseRange)
        {
            // 타겟이 추적 범위 내에 있을 때
            Chase();
        }
        else
        {
            // 타겟이 범위 밖으로 벗어났을 때
            StopChase();
        }
    }
    void StopChase()
    {
        agent.isStopped = true; // 에이전트 멈추도록 설정
     
    }
    void Chase()
    {
        agent.isStopped = false; // 에이전트 움직이도록 설정
        agent.SetDestination(target.position); // 타겟 위치로 이동
    }

    void Attack()
    {
        agent.isStopped = true; // 에이전트 멈추기
        agent.velocity = Vector3.zero; // 에이전트 속도를 0으로 설정
        agent.ResetPath(); // 에이전트의 현재 경로 초기화

        if (Time.time > lastAttackTime + attackDelay)
        {
            lastAttackTime = Time.time; // 마지막 공격 시간 업데이트
            Debug.Log("hit"); // 공격 발생 확인
        }
    }
}
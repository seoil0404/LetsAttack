using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// NavMeshAgent �� ����ϱ� ���� �߰�
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    public Transform target;             // Ÿ��(�÷��̾�) Transform
    public float attackRange = 4f;       // ���� ���� �Ÿ�
    public float attackDelay = 1f;
    public float chaseRange = 10f;       // ���� ���� �Ÿ�// ���� ������ �ð�
    private float lastAttackTime;        // ���������� ������ �ð� ���

    private NavMeshAgent agent;          // NavMeshAgent ������Ʈ

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackRange; // ���� ���� ���� ������ ���ߵ��� ����
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
       // Debug.Log("Distance to Target: " + distanceToTarget); // ������ �α� �߰�

        if (distanceToTarget <= attackRange)
        {
          //  Debug.Log("Within attack range, stopping agent"); // ���� ���� ���� �������� �α׷� ǥ��
            Attack();
        }
        else if (distanceToTarget <= chaseRange)
        {
            // Ÿ���� ���� ���� ���� ���� ��
            Chase();
        }
        else
        {
            // Ÿ���� ���� ������ ����� ��
            StopChase();
        }
    }
    void StopChase()
    {
        agent.isStopped = true; // ������Ʈ ���ߵ��� ����
     
    }
    void Chase()
    {
        agent.isStopped = false; // ������Ʈ �����̵��� ����
        agent.SetDestination(target.position); // Ÿ�� ��ġ�� �̵�
    }

    void Attack()
    {
        agent.isStopped = true; // ������Ʈ ���߱�
        agent.velocity = Vector3.zero; // ������Ʈ �ӵ��� 0���� ����
        agent.ResetPath(); // ������Ʈ�� ���� ��� �ʱ�ȭ

        if (Time.time > lastAttackTime + attackDelay)
        {
            lastAttackTime = Time.time; // ������ ���� �ð� ������Ʈ
            Debug.Log("hit"); // ���� �߻� Ȯ��
        }
    }
}
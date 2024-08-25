using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Windows;

public class pl : MonoBehaviour
{

    [SerializeField]//인스펙터에서만 참조 가능하게
    private float smoothRotationTime;//target 각도로 회전하는데 걸리는 시간
    [SerializeField]
    private float smoothMoveTime;//target 속도로 바뀌는데 걸리는 시간
    [SerializeField]
    private float moveSpeed;//움직이는 속도
    private float rotationVelocity;//The current velocity, this value is modified by the function every time you call it.
    private float speedVelocity;//The current velocity, this value is modified by the function every time you call it.
    private float currentSpeed;
    private float targetSpeed;

    public VariableJoystick joy;
    public float speed;

    Rigidbody rigid;
    Animator anim;
    Vector3 moveVec;

    public GameObject joystickPrefab;  // 조이스틱 프리팹을 참조할 변수
   

    private void Awake()
    {
         joy = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        float x = joy.Horizontal;
        float z = joy.Vertical;

        moveVec = new Vector3(x, 0 , z) * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + moveVec);
        Vector3 inputDir = moveVec;
        //각도를 구해주는 코드, 플레이어가 오른쪽 위 대각선으로 움직일시 그 방향을 바라보게 해준다
        //Mathf.Atan2는 라디안을 return하기에 다시 각도로 바꿔주는 Mathf.Rad2Deg를 곱해준다
        //Vector.up은 y axis를 의미한다
        //SmoothDampAngle을 이용해서 부드럽게 플레이어의 각도를 바꿔준다.
        if(inputDir != Vector3.zero)
        {
            Quaternion dirQuat = Quaternion.LookRotation(moveVec);
            Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
            rigid.MoveRotation(moveQuat);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            GameObject.Find("UI_Manager").GetComponent<UI_Manager>().ReduceHealth();
        }
    }
}

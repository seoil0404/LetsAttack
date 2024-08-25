using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Windows;

public class pl : MonoBehaviour
{

    [SerializeField]//�ν����Ϳ����� ���� �����ϰ�
    private float smoothRotationTime;//target ������ ȸ���ϴµ� �ɸ��� �ð�
    [SerializeField]
    private float smoothMoveTime;//target �ӵ��� �ٲ�µ� �ɸ��� �ð�
    [SerializeField]
    private float moveSpeed;//�����̴� �ӵ�
    private float rotationVelocity;//The current velocity, this value is modified by the function every time you call it.
    private float speedVelocity;//The current velocity, this value is modified by the function every time you call it.
    private float currentSpeed;
    private float targetSpeed;

    public VariableJoystick joy;
    public float speed;

    Rigidbody rigid;
    Animator anim;
    Vector3 moveVec;

    public GameObject joystickPrefab;  // ���̽�ƽ �������� ������ ����
   

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
        //������ �����ִ� �ڵ�, �÷��̾ ������ �� �밢������ �����Ͻ� �� ������ �ٶ󺸰� ���ش�
        //Mathf.Atan2�� ������ return�ϱ⿡ �ٽ� ������ �ٲ��ִ� Mathf.Rad2Deg�� �����ش�
        //Vector.up�� y axis�� �ǹ��Ѵ�
        //SmoothDampAngle�� �̿��ؼ� �ε巴�� �÷��̾��� ������ �ٲ��ش�.
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Bomb_Manager : MonoBehaviour
{
  
    public GameObject BombPrefab;
    public bool IsReflect = false;
    private bool BombSeperate = false;
    private bool BombMultiply = false;
    public float fixAngle;
    public float BombSpeed;
    public float BombMultiplySpeed;

    private Button button;
    private void GenerateBomb(float rotate)
    {
        GameObject bomb = Instantiate(BombPrefab);
        bomb.transform.position = this.transform.position;
        bomb.GetComponent<Bomb_Controller>().IsReflect = IsReflect;
        bomb.GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Sin(rotate) * BombSpeed,
                                                          0, Mathf.Cos(rotate) * BombSpeed), ForceMode.Impulse);
    }

    public void Skill1()
    {
        BombSeperate=true;
    }

    public void Skill2()
    {
        BombMultiply=true;
    }

    public void Skill3()
    {
        IsReflect = true;
    }

    private void _Shoot(float rotate)
    {
        if(BombMultiply)
        {
            StartCoroutine(ShootCoroutine(0, rotate));
            StartCoroutine(ShootCoroutine(BombMultiplySpeed, rotate));
        }
        else
        {
            
            GenerateBomb(rotate);
        }
    }

    IEnumerator ShootCoroutine(float t, float rotate)
    {
        yield return new WaitForSeconds(t);
        GenerateBomb(rotate);
    }

    public void Shoot()
    {
        if(BombSeperate)
        {
            
            _Shoot((transform.rotation.eulerAngles.y-fixAngle)* Mathf.Deg2Rad);
            _Shoot((transform.rotation.eulerAngles.y) * Mathf.Deg2Rad);
            _Shoot((transform.rotation.eulerAngles.y + fixAngle) * Mathf.Deg2Rad);
        }
        else
        {
            _Shoot((transform.rotation.eulerAngles.y) * Mathf.Deg2Rad);
        }
    }
    void OnButtonClick()
    {
        Shoot();
    }
    void Awake()
    {
        // 버튼 컴포넌트를 가져옵니다.
        button = GetComponent<Button>();

        // 버튼이 눌러졌을 때 실행할 함수 연결
        button.onClick.AddListener(OnButtonClick);
    }
}

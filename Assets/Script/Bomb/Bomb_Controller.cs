using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Controller : MonoBehaviour
{
    public bool IsReflect = false;
    public int ReflectCount = 4;
    public GameObject explosion;
    private void Awake()
    {
        StartCoroutine(AutoDestroy());
    }
    private void OnCollisionEnter(Collision collision)
    {
        bool flag1 = !IsReflect || --ReflectCount <= 0;
        bool flag2 = collision.gameObject.layer == 9 || collision.gameObject.layer == 10;
            if (flag1 && collision.gameObject.layer != 11)
            {
                Debug.Log(collision.gameObject.name);
                if(flag2) Instantiate(explosion).GetComponent<Transform>().position = this.transform.position;
                Destroy(gameObject);
            }
            else if(IsReflect && flag2)
            {
            Instantiate(explosion).GetComponent<Transform>().position = this.transform.position;
            }
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

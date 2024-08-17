using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Controller : MonoBehaviour
{
    public bool IsReflect;
    public int ReflectCount = 4;
    public GameObject explosion;
    private bool firstTouch = true;
    private void Awake()
    {
        StartCoroutine(AutoDestroy());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(firstTouch)
        {
            firstTouch = false;
            if (!IsReflect || ReflectCount-- == 0)
            {
                Instantiate(explosion).GetComponent<Transform>().position = this.transform.position;
                Destroy(gameObject);
            }
        }
        else
        {
            if (!IsReflect || ReflectCount-- == 0)
            {
                Instantiate(explosion).GetComponent<Transform>().position = this.transform.position;
                Destroy(gameObject);
            }
        }
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

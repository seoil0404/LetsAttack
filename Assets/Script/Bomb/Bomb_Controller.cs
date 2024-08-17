using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Controller : MonoBehaviour
{
    public bool IsReflect;
    public int ReflectCount = 4;
    public GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        if(!IsReflect || ReflectCount-- == 0)
        {
            Instantiate(explosion).GetComponent<Transform>().position = this.transform.position;
            Destroy(gameObject);
        }
    }
}

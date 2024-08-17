using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Controller : MonoBehaviour
{
    public bool IsReflect;
    public int ReflectCount = 4;

    private void OnCollisionEnter(Collision collision)
    {
        if(!IsReflect || ReflectCount-- == 0)
        {
            Destroy(gameObject);
        }
    }
}

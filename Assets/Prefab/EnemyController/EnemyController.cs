using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool IsDestroy = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Debug.Log('!');
            IsDestroy = true;
        }
    }

    private void Update()
    {
        if (IsDestroy)
        {
            transform.position += Vector3.down * 0.025f;
        }
    }
}

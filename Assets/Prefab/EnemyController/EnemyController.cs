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
            IsDestroy = true;
            GameObject.Find("UI_Manager").GetComponent<UI_Manager>().ClearEnemy();
            Destroy(gameObject, 0.5f);
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

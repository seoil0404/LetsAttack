using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject explosion;
    public float DestroyDelay;
    private bool IsDestroy = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            IsDestroy = true;
            Instantiate(explosion).GetComponent<Transform>().position = this.transform.position;
            Destroy(gameObject, DestroyDelay);
        }
    }

    private void Update()
    {
        if(IsDestroy)
        {
            transform.position += Vector3.down*0.1f;
        }
    }
}

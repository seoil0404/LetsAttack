using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            Instantiate(explosion).GetComponent<Transform>().position = this.transform.position;
            Destroy(gameObject);
        }
    }
}

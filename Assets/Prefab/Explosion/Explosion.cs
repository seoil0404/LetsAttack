using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionTime;
    private void Awake()
    {
        GetComponent<Sound_Controller>().BombSound();
        StartCoroutine(AutoDestroy());
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(ExplosionTime);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject target;
    public void attack()
    {
        target = GameObject.Find("Ship");
        target.GetComponent<Bomb_Manager>().Shoot();
    }
}

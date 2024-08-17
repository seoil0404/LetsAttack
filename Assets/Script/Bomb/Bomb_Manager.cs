using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Manager : MonoBehaviour
{
    public GameObject BombPrefab;
    public bool IsReflect;
    public void GenerateBomb()
    {
        GameObject bomb = Instantiate(BombPrefab);
        bomb.GetComponent<Bomb_Controller>().IsReflect = IsReflect;
        Quaternion rotate = transform.rotation;
        //bomb.GetComponent<Rigidbody>().AddForce(), ForceMode.Impulse);
    }
}

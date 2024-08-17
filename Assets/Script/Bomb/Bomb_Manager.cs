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
        float madeLadaen = 1 / 180 * Mathf.PI;
        bomb.GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Sin(rotate.x*madeLadaen), 
                                                            Mathf.Cos(rotate.y*madeLadaen), 0), ForceMode.Impulse);

    }

    private void Start()
    {
        GenerateBomb();
    }
}

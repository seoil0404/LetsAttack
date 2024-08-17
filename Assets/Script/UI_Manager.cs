using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public int Health = 3;
    public GameObject canvas;
    public RawImage[] health;
    public Texture voidHeart;
    public GameObject InGameObject;
    public GameObject StartGameObject;
    private void Awake()
    {
        DontDestroyOnLoad(canvas);
        InGameObject.SetActive(false);
        StartGameObject.SetActive(true);
    }
    public void ReduceHealth()
    {
        Health--;
        health[Health].texture = voidHeart;
    }

    public void GameStart()
    {
        InGameObject.SetActive(true);
        StartGameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Manager : MonoBehaviour
{
    public int Health = 3;
    private int SceneNumber = 0;
    public int []ClearCount;
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
        if(Health == 0)
        {
            Lose();
        }
    }

    public void ClearEnemy()
    {
        ClearCount[SceneNumber]--;
        if (ClearCount[SceneNumber] == 0)
        {
            if (SceneNumber + 1 >= ClearCount.Length) Win();
            SceneManager.LoadScene(++SceneNumber + 1 + "stage");
        }
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void GameStart()
    {
        Debug.Log("?");
        InGameObject.SetActive(true);
        StartGameObject.SetActive(false);
        SceneManager.LoadScene("1stage");
    }
}

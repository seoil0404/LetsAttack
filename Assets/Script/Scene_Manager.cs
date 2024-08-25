using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Manager : MonoBehaviour
{
    public void End()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Destroy(GameObject.Find("UI_Manager"));
        SceneManager.LoadScene("StartScene");
    }
}

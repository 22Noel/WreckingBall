using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    
}

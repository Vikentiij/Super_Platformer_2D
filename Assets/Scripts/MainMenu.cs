using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    string gameScene;

    public void Play()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Help()
    {
        
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

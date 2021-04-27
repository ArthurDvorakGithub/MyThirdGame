using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play (string levelLabel)
    {
        SceneManager.LoadScene(levelLabel);
    }
    public void Authors()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool toMainMenu;
    void Start()
    {
        toMainMenu = false;
    }
    public void unPause()
    {
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(2);
    }
    public void goMainMenu()
    {
        if (!toMainMenu)
        {
            toMainMenu = true;
            SceneManager.LoadScene(1);
        }
    }
}

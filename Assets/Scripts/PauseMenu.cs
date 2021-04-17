using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void unPause()
    {
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneLoader.LoadScene);
    }
    public void goMainMenu()
    {
        SceneLoader.LoadScene = 0;
        SceneManager.LoadScene(1);
    }
}

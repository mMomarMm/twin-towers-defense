using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool setactive;
    void Update()
    {
        Debug.Log("woorrjking");
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
        SceneManager.LoadScene(0);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
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

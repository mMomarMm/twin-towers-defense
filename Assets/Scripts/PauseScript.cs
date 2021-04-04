using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool isPaused;
    // Start is called before the first frame update
    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}

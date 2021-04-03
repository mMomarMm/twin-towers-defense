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
            Debug.Log("okdijrje");
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }


    }
}

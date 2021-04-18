using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void pauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        } else
        {
            CameraShake.elapsed = 1f;
            Time.timeScale = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameover = false;
    public static bool KonamiCode = false;
    
    //gameover
    private void Update()
    {
        if (KonamiCode)
        {
            Debug.Log(KonamiCode);
        }
        gameover = Torres.gameover;
    }
}

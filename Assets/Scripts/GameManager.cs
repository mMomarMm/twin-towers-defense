﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameover = false;
    public static bool paused;
    //gameover
    private void Update()
    {
        gameover = Torres.gameover;
    }
}

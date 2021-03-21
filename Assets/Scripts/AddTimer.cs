using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AddTimer : MonoBehaviour
{
    public float timeStart;
    public Text textAddtimer;
    bool gameover;
    public static float difficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameManager.gameover;
        timeStart = Time.time;
        difficulty = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover != true)
        {
            //addtimer
            float t = Time.time - timeStart;
            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("F1");
            textAddtimer.text = minutes + ":" + seconds;
            
            //difficulty
            if (t/60 > 1)
            {
                if (t / 60 > 2)
                {
                    difficulty = 0.6f;
                    if (t / 60 > 3)
                    {
                        difficulty = 0.9f;
                        if (t / 60 > 4)
                        {
                            difficulty = 1.2f;
                        }
                    }
                }
            }
        }
    }
}

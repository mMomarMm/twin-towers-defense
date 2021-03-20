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
            float t = Time.time - timeStart;
            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("F1");
            textAddtimer.text = minutes + ":" + seconds;
            if (t/60 == 1)
            {
                Debug.Log("1");
                Invoke("DifficultyTimes2", 0);
            }
        }
    }

    private void DifficultyTimes2()
    {
        difficulty *= 2;
    } 
}

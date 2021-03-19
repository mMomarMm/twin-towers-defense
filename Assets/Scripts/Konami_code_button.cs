using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Konami_code_button : MonoBehaviour
{
    public bool KonamiCode = false;

    // Update is called once per frame
    void Update()
    {
        KonamiCode = GameManager.KonamiCode;
    }
    private const float WaitTime = 1;
    private KeyCode[] keys = new KeyCode[]
    {
        KeyCode.UpArrow,
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.B,
        KeyCode.A,
        KeyCode.B,
        KeyCode.A
    };
    IEnumerator Start()
    {
        float timer = 0f;
        int index = 0;

        while (true)
        {
            if (Input.GetKeyDown(keys[index]))
            {
                index++;

                if (index == keys.Length)
                {
                    timer = 0f;
                    index = 0;
                    KonamiCode = true;
                }
                else
                {
                    timer = WaitTime;
                }
            }
            else if (Input.anyKeyDown)
            {
                // print("Wrong key in sequence.");
                timer = 0;
                index = 0;
            }

            if (timer > 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    timer = 0;
                    index = 0;
                }
            }

            yield return null;
        }
    }
}

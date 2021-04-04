using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private float Xscale;
    private bool toMainMenu;
    // Start is called before the first frame update
    void Start()
    {
        toMainMenu = PauseMenu.toMainMenu;
        Xscale = transform.localScale.x;
        if (toMainMenu)
        {
            StartCoroutine(LoadAsyncOperation2());
            toMainMenu = false;
        }
        else
        {
            StartCoroutine(LoadAsyncOperation());
        }
    }

    IEnumerator LoadAsyncOperation2()
    {
        if (!toMainMenu)
        {
            AsyncOperation gameLevel2 = SceneManager.LoadSceneAsync(0);
            while (gameLevel2.progress < 1)
            {
                Xscale = gameLevel2.progress * 38;
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
    }

    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(2);
        while (gameLevel.progress < 1)
        {
            Xscale = gameLevel.progress * 38;
            yield return new WaitForEndOfFrame();
        }
    }
}

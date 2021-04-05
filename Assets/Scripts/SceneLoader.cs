using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private float Xscale;
    public static int LoadScene;
    
    // Start is called before the first frame update
    void Start()
    {
        Xscale = transform.localScale.x;
        StartCoroutine(LoadAsyncOperation());
    }

    //gamelevel
    IEnumerator LoadAsyncOperation()
    {
        if (LoadScene == 2)
        {
            AsyncOperation gameLevel1 = SceneManager.LoadSceneAsync(2);
            while (gameLevel1.progress < 1)
            {
                Xscale = gameLevel1.progress * 38;
                yield return new WaitForEndOfFrame();
            }
        } 
        else
        {
            AsyncOperation gameLevel0 = SceneManager.LoadSceneAsync(0);
            while (gameLevel0.progress < 1)
            {
                Xscale = gameLevel0.progress * 38;
                yield return new WaitForEndOfFrame();
            }
        }
    }   
}

   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private float Xscale;
    public static int LoadScene;
    public AsyncOperation gameLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        Xscale = transform.localScale.x;
        StartCoroutine(LoadAsyncOperation());
    }

    //gamelevel
    IEnumerator LoadAsyncOperation()
    {
        if (LoadScene != 0)
        {
            gameLevel = SceneManager.LoadSceneAsync(2);
        } 
        else
        {
            gameLevel = SceneManager.LoadSceneAsync(0);
        }
        while (gameLevel.progress < 1)
        {
            Xscale = gameLevel.progress * 38;
            yield return new WaitForEndOfFrame();
        } 
    }   
}

   
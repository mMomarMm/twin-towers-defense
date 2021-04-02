using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private float Xscale;
    // Start is called before the first frame update
    void Start()
    {
        Xscale = transform.localScale.x;
        StartCoroutine(LoadAsyncOperation());
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

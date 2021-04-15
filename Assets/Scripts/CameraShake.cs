using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static float elapsed;
    public IEnumerator Shake (float duration, float magnitude)
    {
        elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(0.5f, 0.7f) * magnitude;
            float y = Random.Range(0.5f, 0.7f) * magnitude;

            transform.position = new Vector3(x, y, -1);

            elapsed += Time.deltaTime;
            
            yield return null;
        }
        transform.position = new Vector3(0, 0, -1);
    }
}

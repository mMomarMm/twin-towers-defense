using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperSpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public Transform spawners;
    public float Xaxis;
    private Vector3 position;
    void Start()
    {
        StartCoroutine(Enemy1Spawn());
    }

    IEnumerator Enemy1Spawn()
    {
        while (AddTimer.SpawnTime != 0)
        {
            float Yaxis = transform.position.y;
            Xaxis = Random.Range(-18.61f, 19.12f);
            spawners.position = new Vector3(Xaxis, Yaxis, 0);
            float r = Random.Range(3, 5);
            yield return new WaitForSeconds(AddTimer.SpawnTime * r);
            Instantiate(Enemy1, spawners);
            if (AddTimer.SpawnTime == 0.4)
            {
                AddTimer.SpawnTime -= 0.03f;
            }
        }
    }
}

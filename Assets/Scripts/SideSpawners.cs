using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSpawners : MonoBehaviour
{
    public GameObject Enemy1;
    public Transform spawners;
    public float Yaxis;
    private Vector3 position;
    void Start()
    {
        StartCoroutine(Enemy1Spawn());
    }

    IEnumerator Enemy1Spawn()
    {
        while (AddTimer.SpawnRate != 0)
        {
            float Xaxis = transform.position.x;
            Yaxis = Random.Range(10.23f, -7.65f);
            spawners.position = new Vector3 (Xaxis, Yaxis, 0);
            yield return new WaitForSeconds(AddTimer.SpawnRate * 3);
            Instantiate(Enemy1, spawners);
        }
    }
}

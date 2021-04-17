using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject torres;
    public GameObject SpawnL;
    public GameObject SpawnR;
    public GameObject FriendlyAirplaneo;
    // Update is called once per frame
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(FriendlyAirplane());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            torres.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }
    
    IEnumerator FriendlyAirplane()
    {
        int r = Random.Range(1, 0);
        yield return new WaitForSeconds(AddTimer.SpawnTime * 2 + 10 + r * 2);
        if (r == 1)
        {
            Instantiate(FriendlyAirplaneo, SpawnL.transform);
        }
        else
        {
            Instantiate(FriendlyAirplaneo, SpawnR.transform);
        }
    }
}

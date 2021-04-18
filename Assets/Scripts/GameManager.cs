using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject torres;
    public GameObject SpawnL;
    public GameObject SpawnR;
    public GameObject FriendlyAirplaneObj;
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
            pauseMenu.SetActive(true);
        }
    }
    
    IEnumerator FriendlyAirplane()
    {
        while (AddTimer.difficulty != 1.2f) 
        {
            int r = Random.Range(1, 0);
            yield return new WaitForSeconds(AddTimer.SpawnTime * 2 * 10 + 50);
            if (r == 1)
            {
                Instantiate(FriendlyAirplaneObj, SpawnL.transform);
            }
            else
            {
                Instantiate(FriendlyAirplaneObj, SpawnR.transform);
            }
        }
    }
}

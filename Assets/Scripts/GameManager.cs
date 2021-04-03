using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject torres;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ookeook");
        if (Input.GetKey(KeyCode.Escape))
        {
            torres.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }
}

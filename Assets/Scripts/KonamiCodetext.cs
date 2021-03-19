using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KonamiCodetext : MonoBehaviour
{
    public bool KonamiCode;
    public Text ON_OFF;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KonamiCode == false)
        {
            ON_OFF.text = "Disablled";
        }
        if (KonamiCode == true)
        {
            ON_OFF.text = "Enabled";
        }
    }
}

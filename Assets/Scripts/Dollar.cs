using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Dollar : MonoBehaviour
{
    public static int dollars;
    public static int newdollars;
    public Text dollarsText;

    void Start()
    {
        dollars = 0;
        newdollars = 0;
    }

    private void Update()
    {
        if (newdollars >= 1)
        {   dollars += newdollars;
            newdollars = 0;
            dollarsText.text = dollars.ToString();
        }
    }
}
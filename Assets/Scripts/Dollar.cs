using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Dollar : MonoBehaviour
{
    public static int dollars;
    public static int newdollars;
    public static Text dollarsText;

    void Start()
    {
        dollars = 0;
        newdollars = 0;
    }
 
    public static IEnumerator GettingDollars()
    {
        newdollars = Enemy.newdollars;
        dollars += newdollars;
        dollarsText.text = dollars.ToString();
        yield return dollarsText;
    }
}
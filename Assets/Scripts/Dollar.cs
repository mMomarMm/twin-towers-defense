using UnityEngine;
using UnityEngine.UI;
public class Dollar : MonoBehaviour
{
    public int dollars;
    public int newdollars;
    public Text dollarsText;

    void Start()
    {
        dollars = 0;
        newdollars = 0;
    }
    public void gettingDollars()
    {
        newdollars = Enemy.newdollars;
        dollars += newdollars;
        dollarsText.text = dollars.ToString();
    }
}
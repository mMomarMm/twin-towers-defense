using UnityEngine;
using UnityEngine.UI;
public class Dollar : MonoBehaviour
{
    public static int dollars;
    public static int newdollars;
    public bool enemy_destroyed;
    public Text dollarsText;

    void Start()
    {
        dollars = 0;
        newdollars = 0;
    }
    void Update()
    {
        enemy_destroyed = Enemy.enemy_destroyed;
        if (enemy_destroyed)
        {
            newdollars = Random.Range(3, -1);
            if (newdollars >= 1)
            {
                newdollars -= 1;
            }
            dollars += newdollars;
        } else
        {
            newdollars = 0;
            enemy_destroyed = false;
        }
        dollarsText.text = dollars.ToString();
    }
}
using UnityEngine;
using UnityEngine.UI;
public class Coins : MonoBehaviour
{
    public static int coins;
    public int newcoins;
    public bool enemy_destroyed;
    public Text dollarsText;

    void Start()
    {
        coins = 0;
        newcoins = 0;
    }
    void Update()
    {
        enemy_destroyed = Enemy.enemy_destroyed;
        if (enemy_destroyed)
        {
            newcoins = Random.Range(3, 0);
            if (newcoins >= 1)
            {
                newcoins -= 1;
            }
            coins += newcoins;
        }

        dollarsText.text = coins.ToString();
    }
}
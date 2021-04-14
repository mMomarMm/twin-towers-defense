using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static bool usando_blaster = true;
    public static bool torreta_comprada = false;
    public GameObject Blaster, Turret;

    public void BuyTurret()
    {
        if (!torreta_comprada || Dollar.dollars >= 150)
        {
            Dollar.dollars -= 150;
            Blaster.SetActive(false);
            Turret.SetActive(true);
        }
    }   
}

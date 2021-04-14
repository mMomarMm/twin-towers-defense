using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static bool usando_blaster = true;
    public static bool torreta_comprada = false;
    public bool wasBought;
    public GameObject Blaster, Turret;
    public Image TbuyButton, CbuyButton, BbuyButton;
    //TbuyButton = turret buy button, CbuyButton = clock buy button, BbuyButton = bomb buy button

    private void Start()
    {
        wasBought = false;
        TbuyButton.GetComponent<Image>().color = new Color32(91, 255, 32, 100);
    }
    public void BuyTurret()
    {
        if (!torreta_comprada && Dollar.dollars >= 150)
        {
            Dollar.dollars -= 150;
            TbuyButton.GetComponent<Image>().color = new Color32(74, 184, 42, 255);
            Blaster.SetActive(false);
            Turret.SetActive(true);
        }
    }   
    public void ShottingTime()
    {
        if (Dollar.dollars >= 50 && !wasBought)
        {
            Weapon.startTimeBtwShots = 0.3f;
            turret_gun.startTimeBtwShots = 0.7f;                                                                         
            wasBought = true;
        }
    }
    public void Bomb()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static bool usando_blaster = true;
    public static bool torreta_comprada = false;
    public bool wasBoughtT, wasBoughtS = false;
    //wasBoughtT = was bought turret, wasBoughtS = was bought shotting time;
    public GameObject Blaster, Turret;
    public Image TbuyButton, CbuyButton, BbuyButton;
    //TbuyButton = turret buy button, CbuyButton = clock buy button, BbuyButton = bomb buy button

    private void Start()
    {
        TbuyButton.GetComponent<Image>().color = new Color32(91, 255, 32, 255);
    }
    public void BuyTurret()
    {
        if (!wasBoughtT && Dollar.dollars >= 150)
        {
            wasBoughtT = true;
            Dollar.dollars -= 150;
            TbuyButton.GetComponent<Image>().color = new Color32(74, 184, 42, 255);
            Blaster.SetActive(false);
            Turret.SetActive(true);
        }
        else
        {
            Blaster.SetActive(true);
            Turret.SetActive(false);
        }
    }   
    public void ShottingTime()
    {
        if (Dollar.dollars >= 50 && !wasBoughtS)
        {
            Weapon.startTimeBtwShots = 0.3f;
            turret_gun.startTimeBtwShots = 0.7f;                                                                         
            wasBoughtS = true;
        }
    }
    public void Bomb()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_flip : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    public float offset;
    bool turret_flip;
    // Start is called before the first frame update

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>(); 
    }
    private void Update()
    {
        turret_flip = turret_gun.turret_flip;
        if (turret_flip)
        {
            spriteRender.flipX = true;
        }
        else 
        {
            spriteRender.flipX = false;
        }
    }
}

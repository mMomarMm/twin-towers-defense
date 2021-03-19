using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public bool stillAlive;
    public float lifeTime;
    public bool usando_blaster = Shop.usando_blaster;

    void Start()
    {
        transform.Rotate(0, 0, -90);
        lifeTime = 3;
    }

    
    private void Update()
    {
        if (usando_blaster) 
        { 
            if (stillAlive == false)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            lifeTime -= 1 * Time.deltaTime;
            if (lifeTime > 0)
            {
                stillAlive = true;
            }
            else
            {
                stillAlive = false;
            }
        }
    }
}

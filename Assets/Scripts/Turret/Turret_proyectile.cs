using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_proyectile : MonoBehaviour
{
    public float speed;
    public bool stillAlive;
    public float lifeTime;
    public bool torreta_comprada = Shop.torreta_comprada;

    void Start()
    {
        transform.Rotate(0, 0, -90);
        lifeTime = 3;
    }


    private void Update()
    {
        if (torreta_comprada)
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

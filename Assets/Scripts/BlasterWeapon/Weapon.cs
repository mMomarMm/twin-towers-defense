using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private SpriteRenderer spriteRender;
    bool usando_blaster;
    public CameraShake CameraShake;

    private void Start()
    {
        usando_blaster = Shop.usando_blaster;
        spriteRender = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (usando_blaster)
        {
            // Handles the weapon rotation
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


            if (rotZ < 89 && rotZ > -89)
            {
                spriteRender.flipY = false;
            }
            else
            {
                spriteRender.flipY = true;
            }

            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    StartCoroutine(CameraShake.Shake(.15f, .4f));
                    timeBtwShots = startTimeBtwShots;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

        }
    }
}
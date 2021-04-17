using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wturret_gun : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    private SpriteRenderer spriteRender;
    public CameraShake CameraShake;
    private float timeBtwShots;
    public static float startTimeBtwShots;

    private void Start()
    {
        startTimeBtwShots = 0;
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!Torres.gameover)
        {
            // Handles the weapon rotation
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);


            if (rotZ < 89 && rotZ > -89)
            {
                spriteRender.flipY = true;
            }
            else
            {
                spriteRender.flipY = false;
            }

            if (timeBtwShots <= 0 && Input.GetMouseButton(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                StartCoroutine(CameraShake.Shake(.15f, .4f));
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}

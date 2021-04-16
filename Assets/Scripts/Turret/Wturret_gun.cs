using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wturret_gun : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    public static bool turret_flip;
    private SpriteRenderer spriteRender;
    public CameraShake CameraShake;
    private float timeBtwShots;
    public static float startTimeBtwShots;
    public bool existSprRen;

    private void Start()
    {
        startTimeBtwShots = 0;
        if (existSprRen)
        {
            spriteRender = GetComponent<SpriteRenderer>();
        }
    }
    private void Update()
    {
        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (rotZ < 89 && rotZ > -89)
        {
            if (existSprRen)
            {
            spriteRender.flipY = false;
            }
            turret_flip = false;
        }
        else
        {
            if (existSprRen)
            {
            spriteRender.flipY = true;
            }
            turret_flip = true;
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

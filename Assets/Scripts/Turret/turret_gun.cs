using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret_gun : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    public static bool turret_flip;

    private float timeBtwShots;
    public float startTimeBtwShots;
    private SpriteRenderer spriteRender;
    public CameraShake CameraShake;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (rotZ < 89 && rotZ > -89)
        {
            spriteRender.flipY = false;
            turret_flip = false;
        }
        else
        {
            spriteRender.flipY = true;
            turret_flip = true;
        }

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                StartCoroutine(CameraShake.Shake(.15f, .45f));
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

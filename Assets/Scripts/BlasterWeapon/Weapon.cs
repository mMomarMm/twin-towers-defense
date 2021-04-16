using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShots;  //time between shots
    public static float startTimeBtwShots;
    private SpriteRenderer spriteRender;
    public CameraShake CameraShake;

    private void Start()
    {
        startTimeBtwShots = 0.7f;
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
                StartCoroutine(CameraShake.Shake(.15f, .3f));
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
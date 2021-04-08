using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform DollarEffectway;
    public static int newdollars;
    public GameObject DollarEffect;
    private SpriteRenderer spriteRender;
    public bool enemy_allive = true;
    public Rigidbody2D rb;
    public float speed = 2f;
    public float difficulty;
    private float x_axis;
    private Vector2 Torres;
    public IEnumerator GettingDollars;
    void Start()
    {
        //declaration
        GettingDollars = Dollar.GettingDollars();
        Torres = new Vector2(0, -6.71999979019165f);
        spriteRender = GetComponent<SpriteRenderer>();
        x_axis = transform.position.x;
        difficulty = AddTimer.difficulty;
        speed += difficulty;
    }

    void Update()
    {
        //movement
        while (enemy_allive)
        {
            transform.position = Vector2.MoveTowards(transform.position, Torres, speed * Time.deltaTime);
        }

        //this needs to be fixed
        if (!enemy_allive)
        {
            StopCoroutine(GetDollarEffect());
        }
        //rotation
        Vector3 torres3 = new Vector3(0, -6.71999979019165f, 0);
        Vector3 difference = torres3 - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (x_axis > 0)
        {
            spriteRender.flipY = true;
        }
        if (x_axis < 0)
        {
            spriteRender.flipY = false;
        }
    }

    //collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Balas")
        {
            StartCoroutine(GetDollarEffect());
        }
    }
    //effects
    IEnumerator GetDollarEffect()
    {
        if (enemy_allive)
        {
            newdollars = Random.Range(3, -1);
            if (newdollars >= 1)
            {
                newdollars -= 1;
            }

            //efects
            if (newdollars >= 1)
            {
                Instantiate(DollarEffect, DollarEffectway);
                StartCoroutine(GettingDollars);
            }
        }
        yield return enemy_allive = true;
    }
}

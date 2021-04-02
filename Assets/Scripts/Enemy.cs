using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform EnemyTransf;
    public int newdollars;
    public GameObject DollarEffect;
    public int dollars;
    private SpriteRenderer spriteRender;
    public static bool enemy_destroyed = false;
    public bool enemy_allive = true;
    public bool gameover;
    public Rigidbody2D rb;
    public float speed = 2f;
    public float difficulty;
    private float x_axis;
    private Vector2 Torres;

    void Start()
    {
        Torres = new Vector2(0, -6.71999979019165f);
        rb = GetComponent<Rigidbody2D>();
        dollars = Dollar.dollars;
        spriteRender = GetComponent<SpriteRenderer>();
        x_axis = transform.position.x;
        speed += difficulty;
        difficulty = AddTimer.difficulty;
        do
        {
           transform.position = Vector2.MoveTowards(transform.position, Torres, speed * Time.deltaTime);
        } while (enemy_allive);
    }

    void Update()
    {
        enemy_destroyed = false;
        newdollars = Dollar.newdollars;
        
        //efects
        if (newdollars >= 1)
        {
            Instantiate(DollarEffect, transform.position);
        }

        //movement
        Vector3 torres3 = new Vector3(0, -6.71999979019165f, 0);
        Vector3 difference = torres3 - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        
        //rotation
        if (x_axis > 0)
        {
            spriteRender.flipY = true;
        }
        if (x_axis < 0)
        {
            spriteRender.flipY = false;
        }
        if (gameover) 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Balas")
        {
            enemy_allive = false;
            enemy_destroyed = true;
            speed = 0;
            difficulty = 0;
        }
    }
}

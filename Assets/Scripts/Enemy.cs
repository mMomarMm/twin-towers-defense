using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int coins;
    public bool KonamiCode;
    private SpriteRenderer spriteRender;
    public static bool enemy_destroyed = false;
    public bool enemy_allive = true;
    public bool gameover;
    public static int newcoins;
    public Rigidbody2D rb;
    public float speed = 2f;
    public Transform Torres;
    public float difficulty;
    private float x_axis;
    public Animation explosion;

    void Start()
    {
    Torres = GameObject.FindGameObjectWithTag("Torres").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        coins = Coins.coins;
        speed += difficulty;
    }

    void FixedUpdate()
    {
        KonamiCode = GameManager.KonamiCode;
        x_axis = transform.position.x;
        spriteRender = GetComponent<SpriteRenderer>();
        difficulty = AddTimer.difficulty;
        gameover = GameManager.gameover;

        if (enemy_allive)
        {
            transform.position = Vector2.MoveTowards(transform.position, Torres.position, speed * Time.deltaTime);
        }

        Vector3 difference = Torres.position - transform.position;

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

        if (gameover) 
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Balas"))
        {
            enemy_allive = false;
            enemy_destroyed = true;
            speed = 0;
            difficulty = 0;
        }
        else
        {
            enemy_allive = true;
            enemy_destroyed = false;
        } 
    }
}

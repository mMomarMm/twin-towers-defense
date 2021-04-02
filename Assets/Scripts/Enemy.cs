﻿using System.Collections;
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
    public Transform Torres;
    public float difficulty;
    private float x_axis;
    public Animation explosion;

    void Start()
    {
    Torres = GameObject.FindGameObjectWithTag("Torres").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        dollars = Dollar.dollars;
        spriteRender = GetComponent<SpriteRenderer>();
        x_axis = transform.position.x;
        speed += difficulty;
        difficulty = AddTimer.difficulty;
        do
        {
           transform.position = Vector2.MoveTowards(transform.position, Torres.position, speed * Time.deltaTime);
        } while (enemy_allive);
    }

    void FixedUpdate()
    {
        enemy_destroyed = false;
        gameover = GameManager.gameover;
        newdollars = Dollar.newdollars;
        
        //efects
        if (newdollars >= 1)
        {
            Instantiate(DollarEffect, EnemyTransf);
        }

        //movement
        Vector3 difference = Torres.position - transform.position;
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

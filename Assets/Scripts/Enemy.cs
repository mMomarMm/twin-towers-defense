﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int isDeadHash;
    Animator animator;
    public Transform DollarEffectway;
    public GameObject DollarEffect;
    private SpriteRenderer spriteRender;
    public static bool enemy_allive = true;
    public Rigidbody2D rb;
    public float speed = 2f;
    private float x_axis;
    private Vector2 Torres;
    void Start()
    {
        //declaration
        enemy_allive = true;
        Torres = new Vector2(0, -6.71999979019165f);
        spriteRender = GetComponent<SpriteRenderer>();
        x_axis = transform.position.x;
        speed += AddTimer.difficulty;
        animator = GetComponent<Animator>();
        isDeadHash = Animator.StringToHash("isDead");
        bool isDead = animator.GetBool(isDeadHash);
    }

    void Update()
    {
        if (transform.parent != null)
        {
            transform.parent = null;
        }
        //movement
        if (enemy_allive)
        {
            transform.position = Vector2.MoveTowards(transform.position, Torres, speed * Time.deltaTime);
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
            Debug.Log("hit");
            animator.SetBool(isDeadHash, true);
            StartCoroutine(GetDollarEffect());
        }
    }
    //effects
    IEnumerator GetDollarEffect()
    {
        if (enemy_allive)
        {
            Dollar.newdollars = Random.Range(2, -2);
            if (Dollar.newdollars >= 1)
            {
                Instantiate(DollarEffect, DollarEffectway);
            }
            yield return new WaitForSeconds(0.4f);
            Destroy(gameObject);
        }
    }
}

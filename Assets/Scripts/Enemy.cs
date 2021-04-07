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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Balas")
        {
            Invoke("getDollarEffect", 0);
            enemy_allive = false;
        }
    }
    IEnumerator getDollarEffect()
    {
        newdollars = Random.Range(3, -1);
        if (newdollars >= 1)
        {
            newdollars -= 1;
            yield return null;
        }
        //efects
        if (newdollars >= 1)
        {
            Instantiate(DollarEffect, DollarEffectway);
            StartCoroutine(GettingDollars);
            yield return null;
        }
    }
}

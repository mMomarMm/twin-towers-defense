using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int isDeadHash;
    Animator animator;
    public Transform DollarEffectway;
    public GameObject DollarEffect;
    private SpriteRenderer spriteRender;
    public Rigidbody2D rb;
    public float speed = 2f;
    public int Percent; //chance of newdollars
    public bool ThisWeird; //is this airplane weird
    private float x_axis;
    private Vector2 Torres;
    bool canMove = true;
    void Start()
    {
        //declaration
        Torres = new Vector2(0, -6.71999979019165f);
        spriteRender = GetComponent<SpriteRenderer>();
        x_axis = transform.position.x;
        speed += AddTimer.difficulty;
        animator = GetComponent<Animator>();
        isDeadHash = Animator.StringToHash("isDead");
        bool isDead = animator.GetBool(isDeadHash);
        if (transform.parent != null)
        {
            transform.parent = null;
        }
    }

    void Update()
    {
        //movement
        if (canMove)
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
            animator.SetBool(isDeadHash, true);
            StartCoroutine(GetDollarEffect());
            canMove = false;
        }
        else if (other.CompareTag("Torres"))
        {
            animator.SetBool(isDeadHash, true);
            StartCoroutine(ThisShouldChange());
        }
    }

    IEnumerator ThisShouldChange()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    //effects
    IEnumerator GetDollarEffect()
    {
        if (ThisWeird)
        {
            Percent = 2;
        }
        else
        {
            Percent = Random.Range(2, -2);
        }
        if (Percent >= 2)
        {
            Dollar.newdollars = Percent;
            Instantiate(DollarEffect, DollarEffectway);
            Percent = 0;
        }
        StartCoroutine(ThisShouldChange());
        yield return null;
    }
}

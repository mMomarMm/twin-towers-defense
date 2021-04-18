using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAvion : MonoBehaviour
{

    int isDeadHash;
    Animator animator;
    public Rigidbody2D rb;
    public float speed = 2f;
    private Vector3 Pointto;
    private Vector3 Goto3;
    private Vector2 Goto;
    public GameObject sound;

    void Start()
    {
        //declaration
        StartCoroutine(ThisShouldChange());
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
        if (transform.position != Goto3)
        {
            transform.position = Vector2.MoveTowards(transform.position, Goto, speed * Time.deltaTime);
        }

        //rotation
        Vector3 difference = Pointto - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    //collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "SpawnL")
        {
            Pointto = new Vector3(20.99f, 8.37f, 0);
            Goto = new Vector2(20.99f, 8.37f);
            Goto3 = new Vector3(20.99f, 8.37f, 0);
            transform.position = new Vector3(-20.99f, 8.37f, 0);
        }
        else if (other.name == "SpawnR")
        {
            Pointto = new Vector3(-20.99f, 8.37f, 0);
            Goto = new Vector2(-20.99f, 8.37f);
            Goto3 = new Vector3(-20.99f, 8.37f, 0);
            transform.position = new Vector3(20.99f, 8.37f, 0);
        }
        if (other.tag == "Balas")
        {
            animator.SetBool(isDeadHash, true);
            Weapon.startTimeBtwShots += 0.05f;
            turret_gun.startTimeBtwShots += 0.05f;
            Wturret_gun.startTimeBtwShots += 0.05f;
            Instantiate(sound, transform);
            transform.position = Goto3;
            StartCoroutine(ThisShouldChange());
        }
    }

    IEnumerator ThisShouldChange()
    {
        yield return new WaitForSeconds(50f);
        Destroy(gameObject);
    }
}

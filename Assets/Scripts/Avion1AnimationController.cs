using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avion1AnimationController : MonoBehaviour
{
    int isDeadHash;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isDeadHash = Animator.StringToHash("isDead");
        bool isDead = animator.GetBool(isDeadHash);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Balas")
        {
            animator.SetBool(isDeadHash, true);
        }
    }
}

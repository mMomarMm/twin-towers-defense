using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torres : MonoBehaviour
{
    int isTouchHash;
    private Animator animator;
    public ParticleSystem smokeleft;
    public ParticleSystem smokeright;
    public Transform smokerightw;
    public Transform smokeleftw;
    public static  Vector3 TorresPosition;
    public static bool gameover;
    public GameObject AddTimer;
    public GameObject GameOScreen;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isTouchHash = Animator.StringToHash("isTouch");
        bool isTouch = animator.GetBool(isTouchHash);
        TorresPosition = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Aviones")
        {
            StartCoroutine(Lose());
        }
    }
    IEnumerator Lose()
    {
        animator.SetBool(isTouchHash, true);
        gameover = true;
        Instantiate(smokeleft, smokeleftw.position, transform.rotation);
        Instantiate(smokeright, smokerightw.position, transform.rotation);
        GameOScreen.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForEndOfFrame();
    }
}

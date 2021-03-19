using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torres : MonoBehaviour
{
    public ParticleSystem smokeleft;
    public ParticleSystem smokeright;
    public Transform smokerightw;
    public Transform smokeleftw;
    public static  Vector3 TorresPosition;
    public static bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameManager.gameover;
    }
    private void Update()
    {
        TorresPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Aviones"))
        {
            gameover = true;
            Instantiate(smokeleft, smokeleftw.position, transform.rotation);
            Instantiate(smokeright, smokerightw.position, transform.rotation);
        }
    }
}

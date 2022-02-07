using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public GameManager gameManager;
    public float fuerzaSalto;

    private Rigidbody2D rigibody;
    private Animator animator;
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update(){
        if (gameManager.start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("EstaSaltando", true);
                rigibody.AddForce(new Vector2(0, fuerzaSalto));
            }
        }

        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("EstaSaltando", false);

        }

        if (collision.gameObject.tag == "obstaculo")
        {
            gameManager.gameOver = true;
        }
    }
}

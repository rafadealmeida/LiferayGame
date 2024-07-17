using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public bool isGrounded = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool goRigth = false;

    public int damage = 10;
    private SanityController sanityController;
    void Start()
    {
        sanityController = FindObjectOfType<SanityController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        isGrounded = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);

        if (!isGrounded)
        {
            speed *= -1;
        }

        if(speed > 0 && goRigth)
        {
            Flip();
        } else if ( speed <0 && !goRigth)
        {
            Flip();
        }
    }

    void Flip()
    {
        goRigth = !goRigth;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayLogic player = collision.gameObject.GetComponent<PlayLogic>();
            if (player != null)
            {
                player.TakeDamage(damage);
                player.anim.SetTrigger("TakeDamage");
                player.kBCount = player.kBTime;
                if (collision.transform.position.x <= transform.position.x)
                {
                    player.isKnoginRight = true;
                }
                if (collision.transform.position.x > transform.position.x)
                {
                    player.isKnoginRight = false;
                }
            }

            if ( sanityController.currentSanity == damage)
            {
                collision.gameObject.GetComponent<Animator>().SetTrigger("Dead");
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                collision.gameObject.GetComponent<PlayLogic>().enabled = false;
                collision.gameObject.GetComponent<Animator>().SetFloat("VerticalAnim", 0);
                Invoke("RealoadScene", 1f);
            }
            
            
        }
    }

    void RealoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

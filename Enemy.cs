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
    private Animator anim;

    public Transform[] pointsToMove;
    private int currentPoint = 0;

    private SanityController sanityController;

    [SerializeField] private AudioClip deathClip; // Adicione esta linha para o áudio de morte
    private AudioSource audioSource; // Adicione esta linha

    void Start()
    {
        sanityController = FindObjectOfType<SanityController>();
        anim = GetComponent<Animator>();

        if (pointsToMove.Length > 0)
        {
            transform.position = pointsToMove[currentPoint].position;
        }

        // Adicione o AudioSource ao GameObject se ainda não existir
        if (GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (pointsToMove.Length > 0)
        {
            MoveBetweenPoints();
        }
        else
        {
            DefaultMove();
        }
    }

    void DefaultMove()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        isGrounded = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);

        if (!isGrounded)
        {
            speed *= -1;
        }

        if (speed > 0 && goRigth)
        {
            Flip();
        }
        else if (speed < 0 && !goRigth)
        {
            Flip();
        }
    }

    void MoveBetweenPoints()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[currentPoint].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, pointsToMove[currentPoint].position) < 0.1f)
        {
            // Flip logic when reaching the point
            if (transform.position.x < pointsToMove[currentPoint].position.x && !goRigth)
            {
                Flip();
            }
            else if (transform.position.x > pointsToMove[currentPoint].position.x && goRigth)
            {
                Flip();
            }

            currentPoint = (currentPoint + 1) % pointsToMove.Length;
        }
    }

    void Flip()
    {
        goRigth = !goRigth;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    public void Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        speed = 0;
        anim.SetTrigger("Death");
        PlayDeathSound(); // Toca o som de morte
        Destroy(gameObject, 1f);
    }

    void PlayDeathSound()
    {
        if (deathClip != null)
        {
            audioSource.PlayOneShot(deathClip, 0.2f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

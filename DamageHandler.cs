using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHandler : MonoBehaviour
{
    public int damage = 10;
    private SanityController sanityController;

    void Start()
    {
        sanityController = FindObjectOfType<SanityController>();
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
                else if (collision.transform.position.x > transform.position.x)
                {
                    player.isKnoginRight = false;
                }
            }

            if (sanityController.currentSanity == damage)
            {
                collision.gameObject.GetComponent<Animator>().SetTrigger("Dead");
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                collision.gameObject.GetComponent<PlayLogic>().enabled = false;
                collision.gameObject.GetComponent<Animator>().SetFloat("VerticalAnim", 0);
                Invoke("ReloadScene", 1f);
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

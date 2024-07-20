using UnityEngine;

public class BearTrap : MonoBehaviour
{
    public Animator anim;
    private Collider2D trapCollider;
    private bool activated = false;
    public int damage = 5;
    private SanityController sanityController;

    void Start()
    {
        anim = GetComponent<Animator>(); 
        trapCollider = GetComponent<Collider2D>();
        sanityController = FindObjectOfType<SanityController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player") && !activated)
        { 
            ActivateTrap();
            
            PlayLogic player = collision.gameObject.GetComponent<PlayLogic>();
            if (player != null)
            {
                player.TakeDamage(damage);
                player.anim.SetTrigger("TakeDamage");
                player.DisableMovement(0.7f);


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

    void ActivateTrap()
    {
        anim.SetTrigger("Activate"); // Dispara o gatilho de ativação na animação
        activated = true; // Marca a armadilha como ativada

        // Desativa o collider da armadilha após um tempo suficiente para a animação ser reproduzida
        Invoke("DisableCollider", 0.5f); // Ajuste o tempo conforme necessário
    }

    void DisableCollider()
    {
        trapCollider.enabled = false; // Desativa o collider da armadilha
    }
}

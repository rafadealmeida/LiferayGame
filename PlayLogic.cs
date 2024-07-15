using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLogic : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDist;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;

    private bool canJump;
    private bool isGroundCheck;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float inputDirection;
    private bool isDirectionRight = true;

    private Rigidbody2D rb2d;

    private SanityController sanityController;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sanityController = FindObjectOfType<SanityController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputMove();
        DirectionCheck();
        CanJump();
        MoveAnim();
        JumpAnim();
    }
    private void FixedUpdate()
    {
        MoveLogic();
        CheckArea();
    }
    void CanJump()
    {
        if(isGroundCheck && rb2d.velocity.y <= 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    void CheckArea()
    {
        isGroundCheck = Physics2D.OverlapCircle(groundCheck.position, groundDist, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDist);
    }

    void DirectionCheck()
    {
        if (isDirectionRight && inputDirection < 0)
        {
            Flip();
        }
        else if (!isDirectionRight && inputDirection > 0)
        {
            Flip();
        }
    }

    void GetInputMove()
    {
        inputDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void MoveLogic()
    {
        rb2d.velocity = new Vector2(inputDirection * moveSpeed, rb2d.velocity.y);
    }

    void MoveAnim()
    {
        anim.SetFloat("HorizontalAnim", rb2d.velocity.x);
    }

    void Flip()
    {
        isDirectionRight = !isDirectionRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    void Jump()
    {
        if (canJump)
        {

        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    void JumpAnim()
    {
        anim.SetFloat("VerticalAnim", rb2d.velocity.y);
        anim.SetBool("GroundCheck", isGroundCheck);
    }

    public void TakeDamage(int damage)
    {
        sanityController.TakeDamage(damage);
        if (sanityController.currentSanity <= 0)
        {
            // Lógica para game over ou respawn
            Debug.Log("Game Over");
        }
    }
    public void RecoverSanity(int amount)
    {
        sanityController.RecoverSanity(amount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Beer"))
        {
            RecoverSanity(20); // Quantidade de sanidade recuperada ao pegar uma cerveja
            Destroy(other.gameObject);
        }
    }

}

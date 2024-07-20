using System.Collections;
using UnityEngine;

public class PlayLogic : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDist;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public Animator anim;

    private bool canJump;
    private bool isGroundCheck;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    public static float inputDirection;
    private bool isDirectionRight = true;

    public float kBForce;
    public float kBCount;
    public float kBTime;

    public bool isKnoginRight;

    private Rigidbody2D rb2d;

    [SerializeField] private bool isAttacking;
    private float attackDuration = 0.1f; // Duração do ataque
    private float attackTimer;

    private SanityController sanityController;
    private bool isMovementEnabled = true; // Flag para controlar se o movimento está habilitado

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sanityController = FindObjectOfType<SanityController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovementEnabled) // Apenas permite movimento se estiver habilitado
        {
            GetInputMove();
        }
        DirectionCheck();
        CanJump();
        MoveAnim();
        JumpAnim();

        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                isAttacking = false;
                anim.SetBool("SimpleAttack", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isMovementEnabled)
        {
            KnockLogic();
            CheckArea();
        }
    }

    void KnockLogic()
    {
        if (kBCount <= 0)
        {
            MoveLogic();
        }
        else
        {
            if (isKnoginRight)
            {
                rb2d.velocity = new Vector2(-kBForce, kBForce);
            }
            else
            {
                rb2d.velocity = new Vector2(kBForce, kBForce);
            }
        }
        kBCount -= Time.deltaTime;
    }

    void CanJump()
    {
        if (isGroundCheck && rb2d.velocity.y <= 0)
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
        if (Input.GetButtonDown("Fire3") && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackDuration;
            anim.SetBool("SimpleAttack", true);
        }

        if (!isAttacking)
        {
            inputDirection = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        else
        {
            inputDirection = 0; // Parar o movimento durante o ataque
        }
    }

    void MoveLogic()
    {
        rb2d.velocity = new Vector2(inputDirection * moveSpeed, rb2d.velocity.y);
    }

    void MoveAnim()
    {
        anim.SetFloat("HorizontalAnim", Mathf.Abs(rb2d.velocity.x));
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
        if (other.gameObject.CompareTag("Beer") && sanityController.currentSanity < 100)
        {
            RecoverSanity(20);
            Destroy(other.gameObject);
        }
    }

    public void DisableMovement(float duration)
    {
        StartCoroutine(DisableMovementCoroutine(duration));
    }

    private IEnumerator DisableMovementCoroutine(float duration)
    {
        isMovementEnabled = false;
        rb2d.velocity = Vector2.zero; // Parar qualquer movimento atual
        yield return new WaitForSeconds(duration);
        isMovementEnabled = true;
    }

    public void EndAnimationATK()
    {
        // Lógica para ser executada ao final da animação
        anim.SetBool("SimpleAttack", false);
        isAttacking = false;
    }

}

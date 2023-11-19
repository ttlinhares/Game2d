using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriterend;

    // Inicialização
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterend = GetComponent<SpriteRenderer>();
    }

    // Atualização a cada frame
    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
        UpdateAnim();
    }

    // Método para movimentar o jogador
    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        Flip(moveX);

        if(moveX > 0f)
        {
            spriterend.flipX = false;

        }
        if (moveX < 0f)
        {
           // animator.SetBool("Run", true);
            spriterend.flipX = true;
        }
        if (moveX == 0f)
        {
            animator.SetBool("Idle", true);
        }

    }
    // Método para flip

    void Flip(float flip)
    {
        if (flip < 0f)
        {
            spriterend.flipX = true;
        //    animator.SetBool("Run", true);

        } else if (flip > 0f)
        {
         //   animator.SetBool("Run", true);
            spriterend.flipX = false;
        }
        if (flip == 0f)
        {
            animator.SetBool("Idle", true);
        }
    }

    // Método para pular
    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        animator.SetBool("Jump", true);
    }

    // Verificar se o jogador está no chão
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Idle", true);
            animator.SetBool("Jump", false);
        }

        if (collision.gameObject.CompareTag("espetos")) ;
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Armadillhas")) ;
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

       
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            
        }
    }

    void UpdateAnim()
    {
        if (!isGrounded && rb.velocity.y < 0)
        {
            animator.SetBool("Fall", true);
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Fall", false);
        }
    }
}

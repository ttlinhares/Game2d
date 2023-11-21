using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriterend;
    private Vector2 checkpointPosition;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterend = GetComponent<SpriteRenderer>();
        checkpointPosition = gameObject.transform.position;
    }
    void Start()
    {
        

        Debug.Log(checkpointPosition.ToString());
        
    }

    
    void Update()
    {
        MovePlayer();
        Jump();
    }

    // Método para movimentar o jogador
    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);


        if(Input.GetAxis("Horizontal") < 0f)
        {
            animator.SetBool("Run", true);
            spriterend.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0f)
        {
            spriterend.flipX = false;
            animator.SetBool("Run", true);
        }
        if (Input.GetAxis("Horizontal") == 0f)

        {
            animator.SetBool("Run", false);
        }


    }

    // Método para pular
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log(rb.velocity.y.ToString());

            if (rb.velocity.y < 0f && isGrounded)
            {
                Debug.Log("O jogador está caindo");
                animator.SetBool("Fall", true);
              
            }
            else if (rb.velocity.y > 0f)
            {
                Debug.Log("O jogador está pulando");
                animator.SetBool("Jump", true);
               
            }
            else
            {
                animator.SetBool("Jump", false);
                animator.SetBool("Fall", false);

            }

            if(!isGrounded)
            {
                if(rb.velocity.y < 0f)
                {
                    animator.SetBool("Fall", true);
                }
            }

        }
        

    }

    // Verificar se o jogador está no chão
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
        }

        if (collision.gameObject.CompareTag("espetos"))
        {
            GameController.instance.ShowGameOver();
            Dead();
        }

        if (collision.gameObject.CompareTag("Armadillhas"))
        {
            GameController.instance.ShowGameOver();
            Debug.Log("Colidiu com armadilha!");
            Dead();
        }
        if (collision.gameObject.CompareTag("armadilhacena2"))
        {
            GameController.instance.ShowGameOver();
            Debug.Log("Colidiu com armadilha!");
            Dead();
        }
        if (collision.gameObject.CompareTag("chegada"))
        {
            GameController.instance.ProximaFase();
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("checkpoint"))
        {
            // Armazene a posição do jogador.
            checkpointPosition = gameObject.transform.position;
            Debug.Log("Ckeckpoint!" + checkpointPosition.ToString());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;          
            
        }
    }



    public void Dead()
    {
        if (checkpointPosition != null)
        {
            gameObject.transform.position = checkpointPosition;
            FindObjectOfType<TentativasController>().Incretentativas();
            Debug.Log("Caiu no true!");

        } else
        {
            Debug.Log("Caiu no else!");
            FindObjectOfType<TentativasController>().Incretentativas();
            GameController.instance.ShowGameOver();
            //Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public PlayerAnimator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        // Verifica se o personagem está se movendo
        if (x != 0)
        {
            Move(x);
            playerAnimator.PlayAnimation("Run"); // Ativa animação de corrida
        }
        else if (isGrounded)
        {
            ;// playerAnimator.PlayAnimation("Player_idle"); // Ativa animação de parado
        }

        // Verifica se o personagem deve pular
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }

        // Verifica se o personagem está caindo
        if (!isGrounded && rb.velocity.y < 0)
        {
            playerAnimator.PlayAnimation("Fall"); // Ativa animação de queda
        }
    }

    void Move(float x)
    {
        Vector2 movement = new Vector2(x * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
        playerAnimator.PlayAnimation("Jump"); // Ativa animação de pulo
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

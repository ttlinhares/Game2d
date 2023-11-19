using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Passaro : MonoBehaviour
{
    private const bool V = false;

    // Start is called before the first frame update

    public float speed = 4f;
    private bool dirRight = true;
    private float timer;
    private GameObject gameobj;
    private SpriteRenderer spriterend;
    private Rigidbody2D rb;

    public float movetime = 3f;
    void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        rb.mass = 0f;
        rb.gravityScale = 0f;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            spriterend.flipX = V;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            spriterend.flipX = true;
        }

        timer += Time.deltaTime;

        if (timer >= movetime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            RestartGame();
        }
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

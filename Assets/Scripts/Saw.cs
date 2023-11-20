using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saw : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private bool dirRight = true;
    private float timer;
    private GameObject gameobj;

    public float movetime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if (timer >= movetime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class sPIKE : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private bool dirup = true;
    private float timer;
    public float movetime;

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        if (dirup)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        
        if(timer >= movetime)
        {
            dirup = !dirup;
            timer = 0f;
        }
    }
}

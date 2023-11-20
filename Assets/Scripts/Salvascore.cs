using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salvascore : MonoBehaviour
{
    public static Salvascore Instance { get; private set; } // Inst�ncia Singleton

    public int variavel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); 
        }
    }
}

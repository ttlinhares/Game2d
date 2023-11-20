using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atualiza : MonoBehaviour
{
    public static Atualiza Instance { get; private set; } // Inst�ncia Singleton

    public int variavel;

    private void Update()
    {
        variavel = Salvascore.Instance.variavel;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Para UI

public class TentativasController : MonoBehaviour
{
    public Text texto;
    private int tentativas = 0;

    void Start()
    {
        Texto();
    }
    private void Update()
    {

    }

    public void Incretentativas()
    {
        tentativas++;
        Texto();
        Salvascore.Instance.variavel = tentativas;
    }

    private void Texto()
    {
        texto.text = tentativas.ToString();
    }
}

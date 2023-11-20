using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Para UI

public class TentativasController1 : MonoBehaviour
{
    public Text texto;
    private int tentativas = 0;

    void Start()
    {
        tentativas = Atualiza.Instance.variavel;
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

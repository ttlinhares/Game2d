using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPainel;
    public static GameController instance;

    void Start()
    {
        instance = this;
    }

   public void ShowGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void fimDeJogo()
    {

    }
   
    public void Restargame()
    {
        SceneManager.LoadScene("cenajogo");
    }

    public void ProximaFase()
    {
        SceneManager.LoadScene("cenajogo1");
    }

    
    
}

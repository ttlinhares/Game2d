using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static GameObject gameOverPainel;
    

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameOverPainel = GameObject.Find("gameOverPainel");
    }

    public void ShowGameOver()
    {
        
        gameOverPainel.SetActive(true);
        
       
    }

    public void Restargame()
    {
        if (SceneManager.GetSceneByName("cenajogo") != null)
        {
            SceneManager.LoadScene("cenajogo");
        }
        else
        {
            Debug.LogError("A cena 'cenajogo' não está na build.");
        }
    }

    public void ProximaFase()
    {
        if (SceneManager.GetSceneByName("cenajogo1") != null)
        {
            SceneManager.LoadScene("cenajogo1");
        }
        else
        {
            Debug.LogError("A cena 'cenajogo1' não está na build.");
        }
    }
}
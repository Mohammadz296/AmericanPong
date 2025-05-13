using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject Score;
    public TextMeshProUGUI playerWonText;
    public ScoreManager scoreManager;
    [HideInInspector] public bool gameIsOver;
    // Start is called before the first frame update
    void Start()
    {
        gameIsOver=false;
        Time.timeScale= 1.0f;
        GameOverScreen.SetActive(false);
        Score.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndGame()
    {
       
        GameOverScreen.SetActive(true);
        Score.SetActive(false);
        Time.timeScale = 0;
        playerWonText.SetText(scoreManager.Victor()+"!!!");
        gameIsOver = true;
    }
}

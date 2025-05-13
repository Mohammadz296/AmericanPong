using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private GameOver gameOver;
    int finalScore;
    int score = 0;
    int score2 = 0;
    private void Start()
    {
        finalScore = PlayerPrefs.GetInt("maxScore",5);
    }
    void Update()
    {
        if (score==finalScore)
        {
            gameOver.EndGame();
           
        }
        else if (score2== finalScore)
        {
            gameOver.EndGame();
          
        }
    }
    public void LeftAddScore(int amount)
    {
       score+= amount;
       
       text.SetText(score.ToString());
    }
    public void RightAddScore(int amount)
    {
       score2+= amount;

       text2.SetText(score2.ToString());
    }
    public string Victor()
    {
        if(score==finalScore)
        {
            return "Player 2 Won";
        }
        if (score2 == finalScore)
        {
            return "Player 1 Won";
        }
        else 
            return "Error";
    }
    
    
}

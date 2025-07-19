using TMPro;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    bool end = false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;
    int finalScore;
    int score = 0;
    int score2 = 0;
    private void Start()
    {
        finalScore = PlayerPrefs.GetInt("maxScore", 5);
    }
    void Update()
    {
        if (score == finalScore&&!end)
        {
            end= true;
            GameManager.instance.GameOver();

        }
        else if (score2 == finalScore && !end)
        {
            end = true;
            GameManager.instance.GameOver();
        }
    }
    public void LeftAddScore(int amount)
    {
        score += amount;

        text.SetText(score.ToString());
    }
    public void RightAddScore(int amount)
    {
        score2 += amount;

        text2.SetText(score2.ToString());
    }
    public string Victor()
    {
        if (score == finalScore)
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

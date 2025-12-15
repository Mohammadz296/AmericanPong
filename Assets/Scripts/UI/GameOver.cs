using TMPro;

public class GameOver : PauseGame
{
    public TextMeshProUGUI playerWonText;

    // Start is called before the first frame update
    private void Start()
    {
        TurnOff();
        GameManager.instance.End += TurnOn;
    }

    public new void TurnOn()
    {
        screen.SetActive(true);
        playerWonText.SetText(ScoreManager.instance.Victor() + "!!!");
    }
}

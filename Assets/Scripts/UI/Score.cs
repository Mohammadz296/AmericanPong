public class Score : PauseGame
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnOn();
        GameManager.instance.End += TurnOff;
    }


}

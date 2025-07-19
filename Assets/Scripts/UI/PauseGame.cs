using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] protected GameObject screen;
      void Start()
    {
        TurnOff();
        GameManager.instance.Pause += TurnOn;
        GameManager.instance.DePause += TurnOff;
    }
    protected void TurnOn()
    {
        screen.SetActive(true);
    }
    protected void TurnOff()
    {
        screen.SetActive(false);
    }
}

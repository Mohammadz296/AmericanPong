using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Game,
        Pause,
        GameOver,

    }
    [SerializeField] EventSystem e;
    [SerializeField] GameObject PauseFirst;
    [SerializeField] GameObject GameEndFirst;
    public State state;
    public Player1 Map;
    public static GameManager instance;
    public Action Pause;
    public Action DePause;
    public Action End;
    private void Update()
    {
        switch (state)
        {
            case State.Game:
                Time.timeScale = 1;
                break;
            case State.Pause:
                Time.timeScale = 0;
                break;
            case State.GameOver:
                Time.timeScale = 0;
                break;

        }
    }
    void changeEventStart(GameObject s)
    {
        e.SetSelectedGameObject(s);
    }
    void PauseUnpause(InputAction.CallbackContext context)
    {
        if (state == State.Pause)
        {
            UnPause();
        }
        else
            PauseGame();

    }

    private void Awake()
    {
        Map = new Player1();
        ToggleActionMap(Map.Player, Map.Player2);
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    public void UnPause()
    {
        ToggleActionMap(Map.Player, Map.Player2);
        state = State.Game;
        DePause?.Invoke();
    }
    public void PauseGame()
    {
        ToggleActionMap();
        changeEventStart(PauseFirst);
        state = State.Pause;
        Pause?.Invoke();
    }
    public void GameOver()
    {
        ToggleActionMap();
        changeEventStart(GameEndFirst);
        state = State.GameOver;
        End?.Invoke();

    }
    public void ToggleActionMap()
    {
        Map.Disable();
    }
    public void ToggleActionMap(InputActionMap actionMap, InputActionMap actionMap2)
    {
        if (actionMap.enabled && actionMap2.enabled)
            return;
        actionMap.Enable();
        actionMap2.Enable();
    }
    private void OnDisable()
    {
        Map.Disable();
    }


}
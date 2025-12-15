using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    [SerializeField] BallMovement bulletPrefab;
    [SerializeField] BallMovement bulletPrefab2;
    [SerializeField] EventSystem e;
    [SerializeField] GameObject PauseFirst;
    [SerializeField] GameObject GameEndFirst;
    public Player1 Map;
    public static GameManager instance;
    public Action Pause;
    public Action DePause;
    public Action End;
   
    void changeEventStart(GameObject s)
    {
        e.SetSelectedGameObject(s);
    }
    void SetupPool()
    {
        GunPooler.Setup(bulletPrefab, 10, "Ball1");
   GunPooler.Setup(bulletPrefab2, 10, "Ball2");
    }

    private void Awake()
    {
        Map = new Player1();
        ToggleActionMap(Map.Player, Map.Player2);
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        Time.timeScale = 1;
        SetupPool();

    }

    public void UnPause()
    {
         Time.timeScale = 1;
        ToggleActionMap(Map.Player, Map.Player2);
        DePause?.Invoke();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        ToggleActionMap();
        changeEventStart(PauseFirst);
        Pause?.Invoke();
    }
    public void GameOver()
    {
          Time.timeScale = 0;
        ToggleActionMap();
        changeEventStart(GameEndFirst);
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
    void OnDisable()
    {
       GunPooler.QueueClear("Ball1");
 GunPooler.QueueClear("Ball2");
        Map.Disable();

    }


}
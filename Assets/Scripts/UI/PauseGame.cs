using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused;
    public int menuScene;
    public int settingsScene;
     void Start()
    {
       PauseMenu.SetActive(false);
    }
     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                UnpauseTheGame();
            }
            else if (!isPaused)
            {
                PauseTheGame();
            }
        }
    }
    public void PauseTheGame()
    {
        isPaused= true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }    
    public void UnpauseTheGame()
    {
        isPaused= false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(menuScene);
    }
    public void Settings()
    {
        SceneManager.LoadScene(settingsScene);
    }
}

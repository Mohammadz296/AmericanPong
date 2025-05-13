using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int gameScene;
    public int settingsScene;
    
    
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void Settings()
    {
        SceneManager.LoadScene(settingsScene);
    }
}

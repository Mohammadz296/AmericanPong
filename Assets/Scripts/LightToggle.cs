using UnityEngine;

public class LightToggle : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.GetInt("isLight",2) != 2)
        {
            gameObject.SetActive(false);
        }
    } 
}

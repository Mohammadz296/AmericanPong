using UnityEngine;

public class MobileControlToggle : MonoBehaviour
{
    [SerializeField] GameObject[] mobilebuttons;
    void Start()
    {
        foreach (GameObject button in mobilebuttons)
        button.SetActive(Application.isMobilePlatform);
        
    }


}

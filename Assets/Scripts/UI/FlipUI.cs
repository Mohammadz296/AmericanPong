using UnityEngine;

public class FlipUI : MonoBehaviour
{
    public GameObject[] panels;
    
    public int panelIndex;
    
    public void FlipPage()
    {
        panels[panelIndex].SetActive(false);
        panelIndex++;
        
        if (panelIndex >= panels.Length)
        {
            panelIndex = 0;
        }
        
        panels[panelIndex].SetActive(true);                
    }
}

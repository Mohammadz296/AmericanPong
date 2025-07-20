using UnityEngine;
using UnityEngine.UI;

public class FlipUI : MonoBehaviour
{
    public GameObject[] panels;
    [SerializeField] Selectable[] DownSelect;
    [SerializeField] Selectable[] UpSelect;
    [SerializeField] Selectable sideButton;
    [SerializeField] Selectable sideButton2;
    [SerializeField] Selectable e;
    Navigation nav;
     int panelIndex;
    private void Awake()
    {
        nav = new Navigation();
        nav.mode = Navigation.Mode.Explicit;
    }
    public void FlipPage(int dir)
    {
        panels[panelIndex].SetActive(false);
        panelIndex+=1*dir;

        if (panelIndex >= panels.Length)
        {
            panelIndex = 0;
        }
        if (panelIndex < 0)
        {
            panelIndex = panels.Length-1;
        }

        panels[panelIndex].SetActive(true);
        NewNav();

    }
    void NewNav()
    {
        nav.selectOnUp = UpSelect[panelIndex];
        nav.selectOnDown = DownSelect[panelIndex];
        NavLeftRight(sideButton2, sideButton,e);
        NavLeftRight(e, sideButton2,sideButton);
        NavLeftRight(sideButton, e, sideButton2);


    }
    void NavLeftRight(Selectable left, Selectable right,Selectable current)
    {
       nav.selectOnLeft= left;
        nav.selectOnRight= right;   
        current.navigation = nav;
    }
}

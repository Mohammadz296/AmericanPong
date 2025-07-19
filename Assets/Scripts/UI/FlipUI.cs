using UnityEngine;
using UnityEngine.UI;

public class FlipUI : MonoBehaviour
{
    public GameObject[] panels;
    [SerializeField] Selectable[] DownSelect;
    [SerializeField] Selectable[] UpSelect;
    [SerializeField] Selectable sideButton;
    [SerializeField] Selectable e;
    Navigation nav;
     int panelIndex;
    private void Awake()
    {
        nav = new Navigation();
    }
    public void FlipPage()
    {
        panels[panelIndex].SetActive(false);
        panelIndex++;

        if (panelIndex >= panels.Length)
        {
            panelIndex = 0;
        }

        panels[panelIndex].SetActive(true);
        NewNav();

    }
    void NewNav()
    {
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnUp = UpSelect[panelIndex];
        nav.selectOnDown = DownSelect[panelIndex];
        nav.selectOnRight = sideButton;
        e.navigation = nav;

    }
}

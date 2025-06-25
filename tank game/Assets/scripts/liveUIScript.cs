using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class liveUIScript : MonoBehaviour
{
    public GameObject[] menuButtons;
    public int currentButton;
    private float navInput = 0;
    public menuScript menu;    // Start is called before the first frame update
    void Start()
    {
        currentButton = 0;
        menuButtons[currentButton].GetComponent<UnityEngine.UI.Image>().color = Color.green;
        Debug.Log(menuButtons);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNavigate(InputAction.CallbackContext context)
    {
        navInput = context.ReadValue<float>();
        if (navInput == 1) 
        {
            currentButton++;
        }
        if (navInput == -1) // bij een positieve input gaat wordt een hogere knop geselecteert, bij een een negatieve input een lagere knop
        {
            currentButton--;
        }
        if (currentButton > (menuButtons.Length-1))
        {
            currentButton = 0;
        }
        if (currentButton < 0) // als de selectie buiten het aantal knoppen valt gaat hij naar de tegenovergestelde kant
        {
            currentButton = menuButtons.Length - 1;
        }
        colorCheck();
    }
    public void colorCheck()
    {
        for (int i = 0; i < menuButtons.Length; i++) // checkt de verschillende knoppen en maakt hen de juiste kleur
        {
            if (i == currentButton)
            {
                menuButtons[i].GetComponent<UnityEngine.UI.Image>().color = Color.green;
            }
            else
            {
                menuButtons[i].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            }
        }
    }
    public void OnSelect(InputAction.CallbackContext context)
    {
        menuButtons[currentButton].GetComponent<Button>().onClick.Invoke();
    }
}

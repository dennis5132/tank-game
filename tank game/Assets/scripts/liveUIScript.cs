using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class liveUIScript : MonoBehaviour
{
    public GameObject[] menuButtons;
    public int currentButton;
    // Start is called before the first frame update
    void Start()
    {
        currentButton = 0;
        //var colors
        //menuButtons[currentButton].GetComponent<Button>().colors = Color.white;
        //var colors = menuButtons[currentButton].GetComponent<Button>().colors;
        //colors.normalColor = Color.red;
        //menuButtons[currentButton].GetComponent<Button>().colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

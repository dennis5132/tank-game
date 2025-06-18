using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void controlsStart()
    {
        SceneManager.LoadScene("ControlsScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void MenuStart()
    {
        SceneManager.LoadScene("menuScene");
    }
}

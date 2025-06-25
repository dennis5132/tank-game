using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
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

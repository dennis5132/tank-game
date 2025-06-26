using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Clip;
    public void gameStart()
    {
        Audio.PlayOneShot(Clip);
        SceneManager.LoadScene("SampleScene");
    }
    public void controlsStart()
    {
        Audio.PlayOneShot(Clip);
        SceneManager.LoadScene("ControlsScene");
    }
    public void quitGame()
    {
        Audio.PlayOneShot(Clip);
        Application.Quit();
    }
    public void MenuStart()
    {
        Audio.PlayOneShot(Clip);
        SceneManager.LoadScene("menuScene");
    }
}

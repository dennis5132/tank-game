using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class controlReturn : MonoBehaviour
{
    public void OnSelect(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("menuScene"); //laad de menuScene vanuit de playerinput
    }
}

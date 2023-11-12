using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    void OnJump(InputValue l_value)
    {
        if (l_value.isPressed == false)
        {
            SceneManager.LoadScene(1);
        }
    }
    void OnQuitGame()
    {
        Application.Quit();
    }
}

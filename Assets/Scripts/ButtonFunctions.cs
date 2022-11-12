using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadControls()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
        print("I will exit on unity builds");
    }
}

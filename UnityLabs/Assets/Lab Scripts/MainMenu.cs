using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("LabMenu");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("InstructionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

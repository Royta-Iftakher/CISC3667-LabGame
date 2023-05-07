using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject pauseMenuScreen;
    [SerializeField] public GameObject pauseButton;

    [SerializeField] public static bool isPaused;

    void Start()
    {
        pauseMenuScreen.SetActive(false);
        pauseButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        pauseMenuScreen.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0.0f;
        isPaused = true;
    }
    public void Resume()
    {
        pauseMenuScreen.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void goToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LabMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject mainMenuUI;
    public GameObject scoreMenuUI;
    public GameObject scoreListUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !mainMenuUI.activeSelf && !scoreMenuUI.activeSelf && !scoreListUI.activeSelf)
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}

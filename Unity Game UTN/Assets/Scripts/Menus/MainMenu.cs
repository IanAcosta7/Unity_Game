using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public float cameraSpeed = 0.5f;
    public Vector3 cameraLocation;
    public Transform mainCamera;
    public Button scoreBoardBtn;
    public GameObject scoreUI;

    private bool play;

    void Start()
    {
        Time.timeScale = 0f;

        if (!File.Exists(Player.path))
        {
            scoreBoardBtn.interactable = false;
        }
    }

    private void Update()
    {
        if (play)
        {
            mainCamera.position = Vector3.MoveTowards(mainCamera.position, cameraLocation, cameraSpeed);
            if (mainCamera.position == cameraLocation)
            {
                play = false;
            }
        }
    }

    public void Play ()
    {
        Time.timeScale = 1f;
        mainMenuUI.SetActive(false);
        scoreUI.SetActive(true);
        play = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public float cameraSpeed = 0.5f;
    public Vector3 cameraLocation;
    public Transform mainCamera;

    private bool play;

    void Start()
    {
        Time.timeScale = 0f;
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
        play = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

}

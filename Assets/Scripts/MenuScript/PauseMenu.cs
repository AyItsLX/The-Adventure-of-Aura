using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameManager gameManager;
    public GameObject PauseUI;
    public GameObject Confirmation;

    private void Awake()
    {
        PauseUI.SetActive(true);
        Confirmation.SetActive(false);
    }

    public void OnResumePressed()
    {
        PauseUI.SetActive(true);
        gameManager.attack.enabled = true;
        gameManager.camScript.enabled = true;
        gameManager.PauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.GamePause = false;
        Confirmation.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnYes()
    {
        Application.Quit();
    }

    public void OnFakeQuit()
    {
        PauseUI.SetActive(false);
        Confirmation.SetActive(true);
    }
}

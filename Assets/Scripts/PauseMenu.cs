using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Awake()
    {
        GameObject.Find("Player").GetComponent<MouseLooker>();
    }

    void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
        {
                LockCursor (false);
                Pause();
        }
	}

    public void Resume ()
    {
        LockCursor(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        GameIsPaused = false;
        Application.Quit();
    }

    private void LockCursor(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

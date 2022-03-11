using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Control the UI in the GameOver screen.
/// </summary>
public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button QuitButton;
    public Button MainMenuButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartButtonClick);
        QuitButton.onClick.AddListener(QuitButtonClick);
        MainMenuButton.onClick.AddListener(MainMenuButtonClick);
    }

    private void MainMenuButtonClick()
    {
        // Load Main menu scene (Lobby scene).
        SceneManager.LoadScene("LobbyScene");
    }

    public void PlayerDied()
    {
        // Enable GameOver screen
        gameObject.SetActive(true);
    }

    public void RestartButtonClick()
    {
        // Reload current scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void QuitButtonClick()
    {
        // Closes application.
        Application.Quit();
    }
}

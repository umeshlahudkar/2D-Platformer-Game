using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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
        SceneManager.LoadScene("LobbyScene");
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene("Level-1");
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }
}

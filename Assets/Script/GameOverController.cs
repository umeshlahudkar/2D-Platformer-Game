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
        // Playing button click sound
        SoundManager.Instance.PlaySFx("ButtonClick");
        // disable mute to play backGround music
        SoundManager.Instance.SoundBgMusic.mute = false;
    }

    public void PlayerDied()
    {
        // Enable GameOver screen
        gameObject.SetActive(true);
        // Muting Background music to play another music for GameOver sreen from Inspector 
        SoundManager.Instance.SoundBgMusic.mute = true;
        
    }

    public void RestartButtonClick()
    {
        // Reload current scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        // Playing button click sound
        SoundManager.Instance.PlaySFx("ButtonClick");
        // disable mute to play backGround music
        SoundManager.Instance.SoundBgMusic.mute = false;
    }

    public void QuitButtonClick()
    {
        // Closes application.
        Application.Quit();
        // Playing button click sound
        SoundManager.Instance.PlaySFx("ButtonClick");
        // disable mute to play backGround music
        SoundManager.Instance.SoundBgMusic.mute = false;
    }
}

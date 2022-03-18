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
    [SerializeField]private Button restartButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private Button MainMenuButton;

  

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartButtonClick);
        QuitButton.onClick.AddListener(QuitButtonClick);
        MainMenuButton.onClick.AddListener(MainMenuButtonClick);
    }

    private void MainMenuButtonClick()
    {
        SceneManager.LoadScene("LobbyScene");
        SoundManager.Instance.PlaySFx("ButtonClick");   // Playing button click sound
        SoundManager.Instance.PlaySoundBgMusic("BgMusic");
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);  // Enable GameOver screen
        
    }

    public void RestartButtonClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        SoundManager.Instance.PlaySFx("ButtonClick");   // Playing button click sound
        SoundManager.Instance.PlaySoundBgMusic("BgMusic");
    }

    public void QuitButtonClick()
    {
        Application.Quit();  // Closes application.
        SoundManager.Instance.PlaySFx("ButtonClick");  // Playing button click sound
        SoundManager.Instance.PlaySoundBgMusic("BgMusic");
    }
}

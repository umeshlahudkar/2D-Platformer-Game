using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the Lobby scene UI
/// </summary>
public class LobbyController : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;

    private void Awake()
    {
        PlayButton.onClick.AddListener(PlayButtonClick);
        QuitButton.onClick.AddListener(QuitButtonClick);
    }

    private void PlayButtonClick()
    {
        // Loads Level-1 scene
        SceneManager.LoadScene("Level-1");
    }

    private void QuitButtonClick()
    {
        // Closese the Aplication
        Application.Quit();
    }
}

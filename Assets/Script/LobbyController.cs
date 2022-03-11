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
    public GameObject LevelSelection;

    private void Awake()
    {
        PlayButton.onClick.AddListener(PlayButtonClick);
        QuitButton.onClick.AddListener(QuitButtonClick);
    }

    private void PlayButtonClick()
    {
        LevelSelection.SetActive(true);
    }

    private void QuitButtonClick()
    {
        // Closese the Aplication
        Application.Quit();
    }
}

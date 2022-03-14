using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the Lobby scene UI and NuttonClick sound
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
        // Playing Button click sound.
        SoundManager.Instance.PlaySFx("ButtonClick");
        //enable Level selection screen
        LevelSelection.SetActive(true);
    }

    private void QuitButtonClick()
    {
        SoundManager.Instance.PlaySFx("ButtonClick");
        // Closese the Aplication
        Application.Quit();
    }
}

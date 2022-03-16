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
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private GameObject LevelSelection;

    private void Awake()
    {
        PlayButton.onClick.AddListener(PlayButtonClick);
        QuitButton.onClick.AddListener(QuitButtonClick);
    }

    private void PlayButtonClick()
    {
        SoundManager.Instance.PlaySFx("ButtonClick");  // Playing Button click sound.
        LevelSelection.SetActive(true);  //enable Level selection screen
    }

    private void QuitButtonClick()
    {
        SoundManager.Instance.PlaySFx("ButtonClick");
        Application.Quit();  // Closese the Aplication
    }
}

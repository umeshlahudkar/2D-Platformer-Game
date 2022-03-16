using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// control Level over screen UI. 
/// </summary>
public class LevelOverController : MonoBehaviour
{
    [SerializeField] private Button MenuButton;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button NextLevelButton;

    private void Awake()
    {
        MenuButton.onClick.AddListener(onMenuButtonClick);
        RestartButton.onClick.AddListener(onRestartButtonClick);
        NextLevelButton.onClick.AddListener(onNextLevelButtonClick);
    }
    public void LevelComplete()
    {
        gameObject.SetActive(true); // enable game over screen
        LevelManager.Instance.MarkLevelComplete();  // calling function MarkLevelComplete() to mark it complete.
        SoundManager.Instance.SoundBgMusic.mute = true; // // Mute backGround music for playing LevelOver screen music.
    }

    public void onRestartButtonClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        SoundManager.Instance.PlaySFx("ButtonClick");  // Playing button click sound
        SoundManager.Instance.SoundBgMusic.mute = false; // disable mute to play backGround music
    }

    public void onMenuButtonClick()
    {
        SceneManager.LoadScene("LobbyScene");
        SoundManager.Instance.PlaySFx("ButtonClick"); // Playing button click sound
        SoundManager.Instance.SoundBgMusic.mute = false; // disable mute to play backGround music
    }

    public void onNextLevelButtonClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneBuildIndex = currentScene.buildIndex + 1;

        SceneManager.LoadScene(nextSceneBuildIndex);

        SoundManager.Instance.SoundBgMusic.mute = false;
    }
}

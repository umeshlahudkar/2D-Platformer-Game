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
    public Button MenuButton;
    public Button RestartButton;

    private void Awake()
    {
        MenuButton.onClick.AddListener(onMenuButtonClick);
        RestartButton.onClick.AddListener(onRestartButtonClick);
    }
    public void LevelComplete()
    {
        // enable game over screen
        gameObject.SetActive(true);
        // calling function MarkLevelComplete() to mark it complete.
        LevelManager.Instance.MarkLevelComplete();
    }

    public void onRestartButtonClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void onMenuButtonClick()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}

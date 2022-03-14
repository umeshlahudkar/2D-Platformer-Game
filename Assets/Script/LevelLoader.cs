using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Load the Level when Levels button pressed.
/// 
/// </summary>

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LevelLoad);
    }

    // Getting the status of Level and loading Levels.
    void LevelLoad()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStastus(LevelName);

        switch (levelStatus)
        {
            case LevelStatus.complete:
                SoundManager.Instance.PlaySFx("ButtonClick");
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.locked:
                SoundManager.Instance.PlaySFx("ButtonClick");
                Debug.Log("Level Locked");
                break;

            case LevelStatus.unlocked:
                SoundManager.Instance.PlaySFx("ButtonClick");
                SceneManager.LoadScene(LevelName);
                break;
        }



    }
}

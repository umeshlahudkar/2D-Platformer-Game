using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Track level Status and marked it Unlocked or Complete
/// </summary>

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    [SerializeField] public string[] levels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GetLevelStastus(levels[0]) == LevelStatus.locked)
        {
            SetLevelStastus(levels[0], LevelStatus.unlocked);
        }
    }

    // After level complete marking it complete and Unlocking Next level. 
    public void MarkLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStastus(currentScene.name, LevelStatus.complete);

        int currenSceneIndex = Array.FindIndex(levels, level => level == currentScene.name);
        int nextSceneIndex = currenSceneIndex + 1;

        if(nextSceneIndex < levels.Length)
        {
            SetLevelStastus(levels[nextSceneIndex], LevelStatus.unlocked);
        }
    }


    public LevelStatus GetLevelStastus(string level)
    {
        LevelStatus levelStastus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStastus;
    }


    // set level status
    public void SetLevelStastus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}

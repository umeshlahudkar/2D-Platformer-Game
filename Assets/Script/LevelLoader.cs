using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Load the Level when related button pressed.
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

    void LevelLoad()
    {
        SceneManager.LoadScene(LevelName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Detects the collision and triggers in the Level.
/// </summary>
public class LevelController : MonoBehaviour
{
    public LevelOverController levelOverController;

    // Detecting triggers of Player and Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.HealthDecrement();

            SoundManager.Instance.PlaySFx("collision");
        }
    }

    // Detecting collision of Player and LevelComplete object.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            levelOverController.LevelComplete();
        }
    }
}

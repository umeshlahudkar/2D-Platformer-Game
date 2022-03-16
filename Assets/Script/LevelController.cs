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
   
    private void OnTriggerEnter2D(Collider2D collision)  // Detecting triggers between Player and Enemy
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.HealthDecrement();

            SoundManager.Instance.PlaySFx("collision");
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)  // Detecting collision between Player and LevelComplete object.
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            levelOverController.LevelComplete();
        }
    }
}

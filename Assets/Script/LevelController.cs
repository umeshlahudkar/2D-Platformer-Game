using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// If Player collides with Enemy or falls from the Platform, calls the HealthDecrement() function from the playerController class.
/// Attached - Enemy 
/// </summary>
public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            // calling function HealthDecrement() if Player collide with Enem or fallen from Platform.
            playerController.HealthDecrement();
        }
    }
}

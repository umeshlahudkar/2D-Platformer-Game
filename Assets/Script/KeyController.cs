using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///   After colliding with Player, Key destroied and call the function KeyPickUp() feom the PlayerController Script.
///   Attached - Key
/// </summary>
public class KeyController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KeyPickUp();

            SoundManager.Instance.PlaySFx("KeyPickUp"); // Playing KeyPickUp sound

            Destroy(gameObject);
        }

    }
}

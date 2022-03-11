using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   After colliding with Player, Key destroied and call the function KeyPickUp() feom the PlayerController Script.
///   Attached - Key
/// </summary>
public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KeyPickUp();
            Destroy(gameObject);
        }
    }
}

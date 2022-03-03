using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Function - Collect Keys
/// Attached on - Key Object
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera Follows the Player.
/// Attached - MainCamera
/// </summary>
public class CameraController : MonoBehaviour
{

    public GameObject Player;
    void Update()
    {
        Vector3 cameraPosition = gameObject.transform.position;
        cameraPosition.x = Player.transform.position.x;
        cameraPosition.y = Player.transform.position.y;

        gameObject.transform.position = cameraPosition; 

    }
}

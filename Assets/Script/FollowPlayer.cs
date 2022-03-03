using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Function - Follows Player
/// Attached on - Camera
/// </summary>
public class FollowPlayer : MonoBehaviour
{

    public GameObject Player;
    void Update()
    {
        Vector3 cameraPosition = gameObject.transform.position;
        //gameObject.transform.position = new Vector3(playerPosition.x, playerPosition.y, gameObject.transform.position.z);
        cameraPosition.x = Player.transform.position.x;
        cameraPosition.y = Player.transform.position.y;

        gameObject.transform.position = cameraPosition; 

    }
}

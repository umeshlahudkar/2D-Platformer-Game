using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject Player;
    void Update()
    {
        Vector3 playerPosition = Player.transform.position;
        gameObject.transform.position = new Vector3(playerPosition.x, playerPosition.y, gameObject.transform.position.z); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control Enemy Movement and Fliping
/// Attached on- Enemy
/// </summary>
public class EnemyController : MonoBehaviour
{
    [SerializeField]private float speed;
    Rigidbody2D rb;
    bool flipEnemy=false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       
        FlipEnemy();
        HorrizontalMovement();

    }

    private void OnTriggerEnter2D(Collider2D collision) // Checking fliping status
    {
        if (collision.gameObject.CompareTag("Flip"))
        {
            flipEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // Checking fliping status
    {
        if (collision.gameObject.CompareTag("Flip"))
        {
            flipEnemy = false;
        }
    }
    void FlipEnemy() // Flip Enemy 
    {
        Vector2 scale = gameObject.transform.localScale;
        if (flipEnemy)
        {
            scale.x = -1f * scale.x;
            speed = -1f * speed; // when Enemy flip, makes Speed '-' so that Enemy move in opposite direction.
        }
        else
        {
            scale.x = 1f*scale.x;
        }
        gameObject.transform.localScale = scale;
    }

    void HorrizontalMovement() // Enemy horrizontal movement
    {
        Vector2 enemyPos = rb.velocity;
        enemyPos.x = speed * Time.deltaTime;
        rb.velocity = enemyPos;
    }
}

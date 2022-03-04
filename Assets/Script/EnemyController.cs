using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Function - Control Enemy Movement and Fliping
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
        Movement();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flip"))
        {
            flipEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flip"))
        {
            flipEnemy = false;
        }
    }
    void FlipEnemy()
    {
        Vector2 scale = gameObject.transform.localScale;
        if (flipEnemy)
        {
            scale.x = -1f * scale.x;
            speed = -1f * speed;
        }
        else
        {
            scale.x = 1f*scale.x;
        }
        gameObject.transform.localScale = scale;
    }

    void Movement()
    {
        Vector2 enemyPos = rb.velocity;
        enemyPos.x = speed * Time.deltaTime;
        rb.velocity = enemyPos;

        //Vector2 pos = gameObject.transform.position;
        //pos.x = speed * Time.deltaTime;
        //gameObject.transform.position = pos;
    }
}

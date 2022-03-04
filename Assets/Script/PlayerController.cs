using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control Player Movement, Animation and Key collection.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    bool crouchEnable;
    bool OnGround;
    bool isJumping;
    public bool IsDead = false;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horrizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");

        if( Mathf.Abs(horrizontalInput) > 0 )
        {
           Run(horrizontalInput);
        }
        

        if ( VerticalInput > 0 && OnGround)
        {
            isJumping = true;
        }
 
        if ( Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouchEnable = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouchEnable = false;
        }

        PlayAnimation(horrizontalInput, VerticalInput, crouchEnable);

        

    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            isJumping = false;
            //OnGround = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            OnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            OnGround = false;
        }
    }

    void Run(float horrizontalInput)  
    {
        Vector2 position = gameObject.transform.position;
        position.x += speed * horrizontalInput * Time.deltaTime;
        gameObject.transform.position = position;
    }

    public void KeyPickUp()  // Key collector
    {
        scoreController.ScoreIncrementer(10);
    }
   
    void PlayAnimation(float horrizontalInput,float VerticalInput, bool crouchEnable) // Contorl Player animation
    {
        // Player Flip
        Vector2 scale = gameObject.transform.localScale;
        if (horrizontalInput > 0)
        {
            scale.x = 1f * Mathf.Abs(scale.x);
        }
        if (horrizontalInput < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        gameObject.transform.localScale = scale;

        // Playing Run Animation
        if (OnGround)
        {
            animator.SetFloat("Speed", Mathf.Abs(horrizontalInput));
        }
        
       
        // Playing Crouch Animation
        if (crouchEnable)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }

        // Playing Jump Animation
        if (OnGround && isJumping)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        animator.SetBool("OnGround", OnGround);

        //Playing Dead animation
        animator.SetBool("isDead", IsDead);
    }
}

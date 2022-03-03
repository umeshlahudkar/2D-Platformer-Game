using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    bool crouchEnable;
    bool OnGround;
    bool isJumping;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horrizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        if( Mathf.Abs(horrizontalInput) > 0)
        {
            Run(horrizontalInput);
        }

        if( VerticalInput > 0 && OnGround)
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
            OnGround = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            OnGround = true;
        }
    }

    void Run(float horrizontalInput)
    {
        Vector2 position = gameObject.transform.position;
        position.x += speed * horrizontalInput * Time.deltaTime;
        gameObject.transform.position = position;
    }

   
    void PlayAnimation(float horrizontalInput,float VerticalInput, bool crouchEnable)
    {
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

        animator.SetFloat("Speed", Mathf.Abs(horrizontalInput));
       

        if (crouchEnable)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }

        if (OnGround && isJumping)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        animator.SetBool("OnGround", OnGround);
    }
}

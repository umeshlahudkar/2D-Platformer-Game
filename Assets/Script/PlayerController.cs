using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Control Player Movement and animation.
/// </summary>
 public class PlayerController : MonoBehaviour
 {
        public ScoreController scoreController;
        public GameOverController gameOverController;
        Animator animator;
        Rigidbody2D rb;

        [SerializeField] private float speed;
        [SerializeField] private float jump;

        bool crouchEnable;
        bool OnGround;
        bool isJumping;
        bool doubleJump;
        public static bool IsDead = false;

        public GameObject[] Health;
        int HealthCount;

        Vector2 InitialPosition;
        int score = 10;
        [SerializeField] private float timeDelay;
        [SerializeField] private float time;


    void Start()
    {
            animator = gameObject.GetComponent<Animator>();
            rb = gameObject.GetComponent<Rigidbody2D>();

            InitialPosition = gameObject.transform.position;

            HealthCount = Health.Length;

    }
    void Update()
    {
        float horrizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = rb.velocity.y;


        if (Mathf.Abs(horrizontalInput) > 0)
        {
            Run(horrizontalInput);
        }


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);  // Playing Crouch animation.
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false); // Playing Crouch animation.
        }


        if (Input.GetKeyDown(KeyCode.UpArrow)) // Jump
        {
            if (OnGround)
            {
                doubleJump = true;
                isJumping = true;
            }
            else if (doubleJump )
            {
                doubleJump = false;
                isJumping = true;
            }
     
        }

         PlayAnimation(horrizontalInput, VerticalInput, crouchEnable);

        if (IsDead)
        {
            timeDelay += Time.deltaTime;
            if(timeDelay > time)
            {
                HealthDecrement();
            }
        }
    }


    private void FixedUpdate()
    {
       if (isJumping)
       {
            Vector2 jumpVelocity = rb.velocity;
            jumpVelocity.x = rb.velocity.x;
            jumpVelocity.y = rb.velocity.y + jump;
            rb.velocity = jumpVelocity;

            isJumping = false;
       }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Checking Status of Player is OnGround or not.
    {
       if (collision.gameObject.tag == "Ground")
       {
                OnGround = true;
           
       }
     }
    private void OnCollisionExit2D(Collision2D collision)  // Checking Status of Player is OnGround or not.
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

            SoundManager.Instance.PlaySFx("Run");
        }

    public void KeyPickUp()  // Key collector
        {
        scoreController.ScoreIncrementer(score);
        }

    void PlayAnimation(float horrizontalInput, float VerticalInput, bool crouchEnable) // Contorl Player animation
        {
            // Playing Player Flip animation
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

            animator.SetBool("OnGround", OnGround);

            animator.SetFloat("jump", VerticalInput);

            animator.SetBool("isDead", IsDead);
    }

    public void HealthDecrement() // Decrementing Player Health.
    {

        if (HealthCount > 1)
        {
            Health[HealthCount - 1].SetActive(false); // Disabling Heart 
            HealthCount -= 1;
            
            gameObject.transform.position = InitialPosition;
        }
        else
        {
            IsDead = true;
            if(timeDelay > time) // to provide delay for playing Death Animation. Delay to open GameOver screen.
            {
                gameOverController.PlayerDied();
                timeDelay = 0;
                IsDead = false;
                SoundManager.Instance.PlaySoundBgMusic("GameOver");
                this.enabled = true;
            }

        }
    }
    
}


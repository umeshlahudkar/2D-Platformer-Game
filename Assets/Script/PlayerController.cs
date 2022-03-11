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
        public bool IsDead = false;
        public GameObject[] Health;
        int HealthCount;
        Vector2 InitialPosition;


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
            float VerticalInput = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(horrizontalInput) > 0)
            {
                Run(horrizontalInput);
            }


            if (VerticalInput > 0 && OnGround)
            {
                isJumping = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                // Playing Crouch animation.
                animator.SetBool("Crouch", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                // Playing Crouch animation.
                animator.SetBool("Crouch", false);
            }

            PlayAnimation(horrizontalInput, VerticalInput, crouchEnable);



        }

        private void FixedUpdate()
        {
            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
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
        }

        public void KeyPickUp()  // Key collector
        {
            scoreController.ScoreIncrementer(10);
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
        }

        public void HealthDecrement() // Decrementing Player Health.
        {

            if (HealthCount > 1)
            {
                // Disable/Decrement Heart when player collides with enemy or fall from Platform.
                Health[HealthCount - 1].SetActive(false);
                // HealthCount = No. of Hearts(Object)
                HealthCount -= 1;
                // When player collides with Enemy or fall from Platform, set player position to its initial position when game start.
                gameObject.transform.position = InitialPosition;
            }
            else
            {
                gameOverController.PlayerDied();

            }
        }
    
}


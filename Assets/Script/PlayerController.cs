using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
   
    void Start()
    {
        animator = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float horrizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");

        Vector2 scale = gameObject.transform.localScale;
        if(horrizontalInput > 0)
        {
            scale.x = 1f * Mathf.Abs(scale.x);
        }
        if(horrizontalInput < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        gameObject.transform.localScale = scale;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }

        if(VerticalInput > 0)
        {
            animator.SetBool("Jump", true);
        }
    }
}

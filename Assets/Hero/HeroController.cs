using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private float runSpeed =8f;
        [SerializeField] private float JumpHeight = 2f;
        [SerializeField] private Transform[] groundChecks;
        [SerializeField] private Transform[] wallChecks;
        [SerializeField] private AudioClip jumpSoundEffect;

        private float gravity = -50f;
        private CharacterController characterController;
        private Vector3 velocity;
        private bool isGrounded;
        private float horizontalInput;
        private Animator animator;
        private bool jumpPressed; 
        private float jumpTimer;
        private float jumpGracePeriod = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        horizontalInput = 1f;
        }

        //FaceForward
        if (horizontalInput == 0)
    {
        // Set the player's forward direction to a predetermined forward direction,
        // such as (1, 0, 0) for example.
        transform.forward = new Vector3(1, 0, 0);
    }
    else
    {
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) -1);
    }
        //isGrounded
        isGrounded = false;

        //groundCheck
        foreach (var groundCheck in groundChecks)
        {
            if (Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                isGrounded = true;
                break;
            }
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
        //Add gravity
        velocity.y += gravity * Time.deltaTime;
        }
        //wallCheck
        var blocked = false;
        foreach (var wallCheck in wallChecks)
        {
            if (Physics.CheckSphere(wallCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                blocked = true;
                break;
            }
        }

        if (!blocked)
        {
            characterController.Move(new Vector3(horizontalInput * runSpeed,0,0) * Time.deltaTime);
        }

        //jump
        jumpPressed = Input.GetButtonDown("Jump");

        if (jumpPressed)
        {
            jumpTimer = Time.time;
        }

        if (isGrounded && (jumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)))
        {
            velocity.y += Mathf.Sqrt(JumpHeight * -2 * gravity);
            if (jumpSoundEffect != null)
            {
                AudioSource.PlayClipAtPoint(jumpSoundEffect, transform.position, 0.5f);
            }
            jumpTimer = -1;
        }
        //vertical velocity
        characterController.Move(velocity * Time.deltaTime);

        animator.SetFloat("Speed", horizontalInput);

        animator.SetBool("IsGrounded", isGrounded);

        animator.SetFloat("VerticalSpeed", velocity.y);
    }
}

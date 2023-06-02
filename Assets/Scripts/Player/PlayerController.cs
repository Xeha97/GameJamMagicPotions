using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Animator animator;
    [SerializeField] private float jumpLength = 0.25f;
    
    public bool canThrow = false;
    public bool canFlip = true;
    public bool canJump = true;
    [SerializeField] private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpStrength = 20f;

    private PlayerInput _playerInput;
    private PlayerInputs _playerInputs;
    private bool isFacingRight = true;
    [SerializeField] public int maxJump = 1;
    private int _jumpsLeft;

    [SerializeField] private Transform potionSpawnPoint;
    [SerializeField] private GameObject potionPrefab;
    [SerializeField] private float throwSpeed = 50f;
    
    [Header("Dash")] 
    public bool canDash = false;
    private bool isDashing = false;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    private PlayFSound playAudio;
    
   


    private void Awake()
    {
        playAudio = GetComponent<PlayFSound>();
        animator = GetComponentInChildren<Animator>();
        _playerInputs = new PlayerInputs();
        _playerInputs.Player.Enable();
        _playerInputs.Player.ThrowPotion.performed += Throw;
        _playerInputs.Player.Dash.performed += StartDash;
    }

    private void Start()
    {
        _jumpsLeft = maxJump;
    }

    private void Update()
    {
        animator.SetFloat("yVelocity", rb.velocity.y);
        if (isDashing)
        {
            return;
        }

        
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("Speed", Math.Abs(horizontal));

        if (IsGrounded() && rb.velocity.y <= 0)
        {
            _jumpsLeft = maxJump;
            animator.SetBool("isJumping", false);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        if (canJump)
        {
            if (context.performed && _jumpsLeft > 0)
            {
                    animator.SetBool("isJumping", true);
                    rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
                    _jumpsLeft -= 1;
            }
        
            if (context.canceled && rb.velocity.y > 0f);
            { 
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                
            }
        }
        else
        {
            return;
        }

    }

    private bool IsGrounded()
    {
        
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void PlayFootstep()
    {
        playAudio.PlaySound();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        

        if (canFlip)
        {
            if (!isFacingRight && horizontal > 0f)
            {
                Flip();
            }
            else if (isFacingRight && horizontal < 0f)
            {
                Flip();
            }
        }
        else
        { 
            return;
        }
    }

    private void Throw(InputAction.CallbackContext context)
    {
        if (context.performed && canThrow)
        {
                var potion = Instantiate(potionPrefab, potionSpawnPoint.position, potionSpawnPoint.rotation);
                potion.GetComponent<Rigidbody2D>().velocity =potionSpawnPoint.up * throwSpeed;
                
        }
        else
        {
            return;
        }
    }

    private void StartDash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash == true)
        {
            StartCoroutine(Dash());
        }
        else
        {
            return;
        }
    }


    IEnumerator JumpAnimFinished()
    {
        yield return new WaitForSeconds(jumpLength);
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling",true);
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

}

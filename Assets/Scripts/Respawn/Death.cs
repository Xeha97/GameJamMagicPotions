using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Death : MonoBehaviour
{
    public PlayerController _playerController;
    [SerializeField] private Animator _animator;
    public Vector2 checkpointPos;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D rb;
    
    void Start()
    {
        
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Deathzone"))
        {
            
            Die();
        }
    }

    public void Updatecheckpoint(Vector2 currentPos)
    {
        checkpointPos = currentPos;
    }
    
    private void Die()
    {
        _animator.Play("FadeInAndOut");
        _playerController.canFlip = false;
        _playerController.canJump = false;
        StartCoroutine(Respawn(.5f));
        StartCoroutine(Fade(1.5f));
    }
    

    IEnumerator Respawn(float duration)
    {
        rb.velocity = new Vector2(0, 0);
        rb.simulated = false;
        _spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        _spriteRenderer.enabled = true;
        rb.simulated = true;
        _playerController.canFlip = true;
        _playerController.canJump = true;
    }

    IEnumerator Fade(float duration)
    {
        yield return new WaitForSeconds(duration);
        _animator.Play("NoFade");
    }
}

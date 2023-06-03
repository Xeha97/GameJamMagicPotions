using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Death deathScript;
    private SpriteRenderer _spriteRenderer;
    
    public Transform respawnPoint;
    public Sprite passive, active;
    
    private PlayFSound playAudio;


    private void Awake()
    {
        playAudio = GetComponent<PlayFSound>();
        deathScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        deathScript.Updatecheckpoint(respawnPoint.position);
        _spriteRenderer.sprite = active;
        if (collider2D.transform.CompareTag("Player"))
        {
            if (playAudio.enabled)
            {
                playAudio.PlaySound();
                playAudio.enabled = false;
            }
            else
            {
                return;
            }
            
            
        }
        
    }

   
}

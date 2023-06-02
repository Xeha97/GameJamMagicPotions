using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPotion : MonoBehaviour
{
    private PlayFSound playAudio;
    public float life = 3f;


    private void Awake()
    {
        playAudio = GetComponent<PlayFSound>();
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        playAudio.PlaySound();
        if (col.transform.CompareTag("Thorns"))
        {
            Destroy(col.gameObject);
        }
    }
}

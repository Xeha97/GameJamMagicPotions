using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterAnimation : MonoBehaviour
{
    [SerializeField] float endAnim = 0.25f;
    private Animator _animator;
    private PlayFSound playAudio;
    private void Awake()
    {
        playAudio = GetComponent<PlayFSound>();
        _animator = GetComponent<Animator>();
    }


    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playAudio.PlaySound();
            _animator.SetBool("PortalStarted", true);
            StartCoroutine(EndAnimation());
        }
    }

    IEnumerator EndAnimation()
    {
        yield return new WaitForSeconds(endAnim);
        _animator.SetBool("PortalStarted", false);
        _animator.SetBool("PortalStartedFinished", true);
    }
}

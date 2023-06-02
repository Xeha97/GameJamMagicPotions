using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomDeath : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _deathZone;
    [SerializeField] private Collider2D triggerCol;


    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Geht");
            StartCoroutine(StartShroom(0.25f));
            _animator.Play("ShroomPoof");
        }
    }

    private void ShroomGoesBrr()
    {
        triggerCol.enabled = false;
        _deathZone.SetActive(true);
    }

    private void ShroomIsCalm()
    {
        _deathZone.SetActive(false);
        triggerCol.enabled = true;
        _animator.Play("ShroomIdle");
    }

    IEnumerator StartShroom(float duration)
    {
        yield return new WaitForSeconds(duration);
        
    }
}

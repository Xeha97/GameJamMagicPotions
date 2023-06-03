using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowTutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutText;
    [SerializeField] private Collider2D tutEnd;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tutText.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastCollect : MonoBehaviour
{
    [SerializeField] private GameObject collectedItem;
    [SerializeField] private TMP_Text collectedText;

    [SerializeField] private LastCollectManager cm;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            cm.LastPotion();
            collectedText.color = Color.green;
            Destroy(gameObject);
        }
    }
}

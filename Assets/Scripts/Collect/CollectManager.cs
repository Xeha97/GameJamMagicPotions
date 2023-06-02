using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectManager : MonoBehaviour
{
    private Collectible _collectible;
    private int collectAmount = 0;
    [SerializeField] private GameObject potionReady;
    [SerializeField] public GameObject baseCollider;
    


    public void CollectPotion()
    {
        collectAmount++;

        if (collectAmount >= 3)
        {
            
            baseCollider.SetActive(true);
            
        }
    }

    public void UseItem()
    {
        
    }
}


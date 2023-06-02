using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCollectManager : MonoBehaviour
{
    
        private Collectible _collectible;
        private int lastCollectAmount = 0;
        [SerializeField] private GameObject potionReady;
        [SerializeField] public GameObject baseCollider;

        public void LastPotion()
        {
            lastCollectAmount++;

            if (lastCollectAmount >= 3)
            {
                baseCollider.SetActive(true);
            }
        }

        public void UseItem()
        {

        }
    
}

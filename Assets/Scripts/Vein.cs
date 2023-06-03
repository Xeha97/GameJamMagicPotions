using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vein : MonoBehaviour
{
    [SerializeField] private GameObject veinCol;
    [SerializeField] private Animator _animator;

    public void VeinDies()
    {
        veinCol.SetActive(false);
        _animator.Play("vein died");
    }
}

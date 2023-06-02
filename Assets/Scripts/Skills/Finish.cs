using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Finish : MonoBehaviour
{
    [SerializeField] private Animator _fade;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject toDoList;
    [SerializeField] private float endScreenTime = 5f;
    private bool canTrigger = false;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        PlayerInputs playerInputs = new PlayerInputs();
        playerInputs.Player.Enable();
        playerInputs.Player.Interact.performed += Interact;
    }
    
    
    private void OnTriggerStay2D(Collider2D col)
    {
        canTrigger = true;
        icon.SetActive(true);
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        canTrigger = false;
        icon.SetActive(false);
    }
    private void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && canTrigger == true)
        {
            _animator.SetBool("isBrewingQ3", true);
            canTrigger = false;
            FinishScreen();
        }
    }

    private void FinishScreen()
    {
        toDoList.SetActive(false);
        endScreen.SetActive(true);
        StartCoroutine(FinishTrigger());
    }
    

        IEnumerator FinishTrigger()
        {
            yield return new WaitForSeconds(endScreenTime);
            SceneManager.LoadScene("MainMenu");
        }
}

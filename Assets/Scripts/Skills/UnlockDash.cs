using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnlockDash : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject disableQuest;
    [SerializeField] private GameObject enableQuest;
    [SerializeField] private GameObject disableCollider;
    [SerializeField] private PlayerController pc;
    [SerializeField] private GameObject nextMission;
    [SerializeField] private GameObject lastMission;
    [SerializeField] private CollectManager cm;
    private PlayerInput _playerInput;
    private bool canTrigger = false;
    private float wait = 2f;


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        PlayerInputs playerInputs = new PlayerInputs();
        playerInputs.Player.Enable();
        playerInputs.Player.Interact.performed += Interact;
    }
    
    private void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && canTrigger == true)
        {
            _animator.SetBool("isBrewingQ2", true);
            canTrigger = false;
            Unlock();
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            icon.SetActive(true);
            canTrigger = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        canTrigger = false;
        icon.SetActive(false);
    }
    private void Unlock()
    {
        disableQuest.SetActive(false);
        pc.canDash = true;
        lastMission.SetActive(false);
        nextMission.SetActive(true);
        enableQuest.SetActive(true);
        StartCoroutine(KesselAus());
    }
    IEnumerator KesselAus()
    {
        yield return new WaitForSeconds(wait);
        _animator.SetBool("isBrewingQ2", false);
        disableCollider.SetActive(false);
        cm.baseCollider.SetActive(false);
        
    }
}

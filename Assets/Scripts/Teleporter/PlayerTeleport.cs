using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleport : MonoBehaviour
{
     [SerializeField] private GameObject icon;
     public GameObject portal;
     private GameObject player;
     private GameObject currentTeleporter;
     private PlayerInput _playerInput;
     private PlayerController pc;
     private bool canTrigger = false;

     private void Awake()
     {
          pc = GetComponent<PlayerController>();
          _playerInput = GetComponent<PlayerInput>();
          PlayerInputs playerInputs = new PlayerInputs();
          playerInputs.Player.Enable();
          playerInputs.Player.Interact.performed += Interact;
     }
     
     private void Start()
     {
          player = GameObject.FindWithTag("Player");
     }

     private void OnTriggerEnter2D(Collider2D col)
     {
          if (col.CompareTag("Teleporter"))
          {
               currentTeleporter = col.gameObject;
          }
     }

     private void OnTriggerExit2D(Collider2D col)
     {
          icon.SetActive(false);
          canTrigger = false;
          if (col.CompareTag("Teleporter"))
          {
               if (col.gameObject == currentTeleporter)
               {
                    currentTeleporter = null;
               }
          }
     }

     private void OnTriggerStay2D(Collider2D other)
     {
          if (other.CompareTag("Teleporter"))
          {
               icon.SetActive(true);
               canTrigger = true;
          }
     }
     
     

     private void Interact(InputAction.CallbackContext context)
     {
          if (context.performed && currentTeleporter != null && canTrigger == true)
          {
               canTrigger = false;
               transform.position = currentTeleporter.GetComponent<TeleportDestination>().GetDestination().position;
          }
     }
}

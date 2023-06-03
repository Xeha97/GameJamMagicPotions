using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    private InputAction menu;

    private EventSystem _eventSystem;
    
    

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        
    }
    
    private void OnEnable()
    {
        menu = _playerInputs.Menu.OpenMenu;
        menu.Enable();
    }

    private void OnDisable()
    {
        menu.Disable();
    }
    
    public void QuitGame()
    {
        Debug.Log("lakdjfhgkjafdhgbvj");
        Application.Quit();
    }
    
}

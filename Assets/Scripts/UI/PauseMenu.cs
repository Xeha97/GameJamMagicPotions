using System;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    private InputAction menu;
    public PlayerController _playerController;

    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject continueButton;

    private EventSystem _eventSystem;
    
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject menuUI;
    public bool isPaused;

    private void Awake()
    {
        _eventSystem = EventSystem.current;
        _playerInputs = new PlayerInputs();
    }
    

    private void OnEnable()
    {
        menu = _playerInputs.Menu.OpenMenu;
        menu.Enable();

        menu.performed += Pause;
        
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    public void Pause(InputAction.CallbackContext ctx)
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    private void ActivateMenu()
    {
        _eventSystem.SetSelectedGameObject(resumeButton);
        _playerController.canFlip = false;
        _playerController.canJump = false;
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        
    }

    public void DeactivateMenu()
    {
        _playerController.canFlip = true;
        _playerController.canJump = true;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        menuUI.SetActive(false);
        isPaused = false;
    }

    public void SetMenuButton()
    {
        _eventSystem.SetSelectedGameObject(backButton);
    }
    
    public void SetPauseButton()
    {
        _eventSystem.SetSelectedGameObject(resumeButton);
    }

    public void SetContinueButton()
    {
        _eventSystem.SetSelectedGameObject(continueButton);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    
}

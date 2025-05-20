using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private PlayerAction _playerAction;
    private InputAction _pause;
    private void Awake()
    {
        _playerAction = new PlayerAction();
    }

    private void OnEnable()
    {
        _pause = _playerAction.Player.Pause;
        _pause.Enable();
        _pause.started += Pausing;
    }

    private void OnDisable()
    {
        _pause.Disable();
        _pause.started -= Pausing;
    }
    private void Pausing(InputAction.CallbackContext context)
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

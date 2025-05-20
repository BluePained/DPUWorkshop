using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform parentPlayer;
    [Range(0.01f, 2f)][SerializeField] private float mouseSensitivity;
    private Vector2 _mousePosition;
    private float _currentX;
    private readonly float _minRotX = -85f;
    private readonly float _maxRotX = 85f;
    private PlayerAction _playerAction;

    private void Awake()
    {
        _playerAction = new PlayerAction();  
    }

    private void OnEnable()
    {
        _playerAction.PlayerInput.Enable();
    }

    private void OnDisable()
    {
        _playerAction.PlayerInput.Disable();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        _mousePosition = _playerAction.PlayerInput.MousePosition.ReadValue<Vector2>() * (0.2f * mouseSensitivity);
        RotationMovement();
    }

    private void RotationMovement()
    {
        parentPlayer.transform.Rotate(0, _mousePosition.x, 0);

        _currentX -= _mousePosition.y;
        _currentX = Mathf.Clamp(_currentX, _minRotX, _maxRotX);
       transform.localRotation = Quaternion.Euler(_currentX, 0f, 0f);
    }
}

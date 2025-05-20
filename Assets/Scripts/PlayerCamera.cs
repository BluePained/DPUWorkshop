using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform parentPlayer;
    [Range(0.01f, 2f)][SerializeField] private float mouseSensitivity;
    private PlayerAction _playerAction;
    private Vector2 _mousePosition;
    private float _currentX;
    private const float MinRotX = -85f;
    private const float MaxRotX = 85f;

    private void Awake()
    {
        _playerAction = new PlayerAction();
    }

    private void OnEnable()
    {
        _playerAction.Player.Look.Enable();
    }

    private void OnDisable()
    {
        _playerAction.Player.Look.Disable();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }
        _mousePosition = _playerAction.Player.Look.ReadValue<Vector2>() * (0.2f * mouseSensitivity);

        RotationMovement();
    }

    private void RotationMovement()
    {
        parentPlayer.transform.Rotate(0, _mousePosition.x, 0);

        _currentX -= _mousePosition.y;
        _currentX = Mathf.Clamp(_currentX, MinRotX, MaxRotX);
       transform.localRotation = Quaternion.Euler(_currentX, 0f, 0f);
    }
}

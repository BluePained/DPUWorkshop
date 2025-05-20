using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerInput  _playerInput;
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveDirection = (transform.forward *  _playerInput.actions["Movement"].ReadValue<Vector3>().z) + (transform.right * _playerInput.actions["Movement"].ReadValue<Vector3>().x);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _moveDirection * (speed * Time.deltaTime) +  new Vector3(0,_rigidbody.velocity.y,0);
    }
    

    
}

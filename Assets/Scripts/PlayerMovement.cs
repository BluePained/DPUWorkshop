using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    private PlayerAction _playerAction;
    private Vector3 _moveDirection;

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
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        _moveDirection = (transform.forward *  _playerAction.PlayerInput.Movement.ReadValue<Vector3>().z) + (transform.right * _playerAction.PlayerInput.Movement.ReadValue<Vector3>().x);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _moveDirection * (speed * Time.deltaTime) +  new Vector3(0,_rigidbody.velocity.y,0);
    }
    

    
}

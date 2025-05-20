using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private RayCaster rayCaster;
    [SerializeField] private GameObject highlightObject;
    private RaycastHit _hit;
    private IInteractable _interactable;
    private PlayerAction _playerAction;
    private InputAction _interaction;
    private void Awake()
    {
        _playerAction = new PlayerAction();
    }
    private void OnEnable()
    {
        _interaction = _playerAction.Player.Interact;
        _interaction.Enable();
        _interaction.started += Interact;
    }

    private void OnDisable()
    {
        _interaction.Disable();
        _interaction.started -= Interact;
    }
    private void Start()
    {
        rayCaster = GetComponent<RayCaster>();
    }

    private void FixedUpdate()
    {
        _hit = rayCaster.RaycastingInteraction();
        
        if (_hit.collider && _hit.collider.gameObject != highlightObject)
        {
            highlightObject = _hit.collider.gameObject;

            _interactable?.UnInteracted();
            _interactable = null;

            if (_hit.collider.TryGetComponent(out IInteractable newInteractable))
            {
                highlightObject = _hit.collider.gameObject;
                _interactable = newInteractable;
                _interactable.Interactable();
            }

        }
        else if (!_hit.collider && _interactable != null)
        {
            highlightObject = null;
            _interactable.UnInteracted();
            _interactable = null;
        }
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (highlightObject != null && _interactable != null)
        {
            _interactable.Interacted(gameObject);
            highlightObject = null;
            _interactable = null;
        }
        else
        {
            return;
        }
    }
}

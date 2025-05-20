using System;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private RayCaster rayCaster;
    [SerializeField] private GameObject highlightObject;
    private IInteractable _interactable;
    private void Start()
    {
        rayCaster = GetComponent<RayCaster>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit = rayCaster.RaycastingInteraction();
        
        if (hit.collider && hit.collider.gameObject != highlightObject)
        {
            highlightObject = hit.collider.gameObject;

            _interactable?.UnInteracted();
            _interactable = null;

            if (hit.collider.TryGetComponent(out IInteractable newInteractable))
            {
                highlightObject = hit.collider.gameObject;
                _interactable = newInteractable;
                _interactable.Interactable();
            }

        }
        else if (!hit.collider && _interactable != null)
        {
            highlightObject = null;
            _interactable.UnInteracted();
            _interactable = null;
        }
    }
}

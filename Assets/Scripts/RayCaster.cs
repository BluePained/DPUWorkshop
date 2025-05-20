using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Transform RaycastorPos;
    [SerializeField] private float dist;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(RaycastorPos.position, transform.TransformDirection(Vector3.forward) * dist);
    }

    public RaycastHit RaycastingInteraction()
    {
        Vector3 direction = transform.forward;
        Physics.Raycast(RaycastorPos.position, direction, out RaycastHit hit, dist);
        return hit;
    }
}

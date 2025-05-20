using UnityEngine;

public class ItemHighlighter : MonoBehaviour, IInteractable
{
    [SerializeField] private Material[] highlightMaterial = new Material[2];
    [SerializeField] private Material[] defaultMaterial = new Material[1];
    [SerializeField] private MeshRenderer meshRenderer;
    
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.sharedMaterials;
        highlightMaterial[0] = meshRenderer.sharedMaterials[0];

    }

    public void UnInteracted()
    {
        meshRenderer.materials = defaultMaterial;
    }

    public void Interactable()
    {
        meshRenderer.materials = highlightMaterial;
    }

    public virtual void Interacted(GameObject player)
    { 
        
    }
}

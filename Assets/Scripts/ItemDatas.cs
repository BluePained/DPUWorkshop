using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Item", menuName = "Create/ItemData")]
public class ItemDatas : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private Sprite itemSprite;
    [SerializeField, TextArea] private string itemDescription;
    
    public Sprite ItemSprite => itemSprite;
    public string Name => string.IsNullOrWhiteSpace(displayName) ? this.name : displayName;
    public string ItemDescription => itemDescription;
}

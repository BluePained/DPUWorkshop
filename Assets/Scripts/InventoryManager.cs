using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject[] slots;
    [SerializeField] private string[] itemNames;
    [SerializeField] private ItemDatas[] itemDataStore;
    [SerializeField] private TMP_Text[] slotTexts;

    [SerializeField] private Image desImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text desText;
        
    private PlayerAction _playerAction;
    private InputAction _inventoryAction;

    private void Awake()
    {
        _playerAction = new PlayerAction();
    }

    private void OnEnable()
    {
        _inventoryAction = _playerAction.UI.Inventory;
        _inventoryAction.Enable();
        _inventoryAction.started += CheckInventory;
    }

    private void OnDisable()
    {
        _inventoryAction.Disable();
        _inventoryAction.started -= CheckInventory;
    }

    private void CheckInventory(InputAction.CallbackContext context)
    {
        if (inventoryPanel.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inventoryPanel.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inventoryPanel.SetActive(true);
        }
    }

    public void AddingToInventory(ItemDatas itemData)
    {
       for(int i = 0; i < itemNames.Length; i++)
       {
           if (slots[i].activeSelf && itemNames[i] == itemData.Name)
           {
               int currentCount = int.Parse(slotTexts[i].text);
               currentCount++;
               slotTexts[i].text = currentCount.ToString();
               return;
           }
       }

       for (int i = 0; i < slots.Length; i++)
       {
           if (!slots[i].activeSelf)
           {
               slots[i].SetActive(true);
               slots[i].GetComponent<Image>().sprite = itemData.ItemSprite;
               itemNames[i] = itemData.Name;
               slotTexts[i].text = "1";
               itemDataStore[i] = itemData;
               return;
           }
       }
    }

    public void AddToDescription(int index)
    {
        desImage.gameObject.SetActive(true);
        nameText.gameObject.SetActive(true);
        desText.gameObject.transform.parent.gameObject.SetActive(true);
        desText.gameObject.SetActive(true);
        
        desImage.sprite = itemDataStore[index].ItemSprite;
        nameText.text = itemDataStore[index].Name;
        desText.text = itemDataStore[index].ItemDescription;
        
    }
}

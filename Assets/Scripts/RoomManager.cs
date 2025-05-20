using UnityEngine;

public class RoomManager : MonoBehaviour
{
  [SerializeField] private GameObject door;
  [SerializeField] private GameObject[] items;
  [SerializeField] private bool isWon;
  public bool IsWon => isWon;

  private void Start()
  {
    GameObject[] foundItems = GameObject.FindGameObjectsWithTag("Item");
    int count = Mathf.Min(items.Length, foundItems.Length);
    for (int i = 0; i < items.Length; i++)
    {
      items[i] = foundItems[i];
    }
  }
  private void FixedUpdate()
  {
    if (!isWon && AllItemsCleared())
    {
      isWon = true;
      door.SetActive(false);
    }
  }
  private bool AllItemsCleared()
  {
    foreach (GameObject item in items)
    {
      if (item != null) return false;
    }
    return true;
  }
}



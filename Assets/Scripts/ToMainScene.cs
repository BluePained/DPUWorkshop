using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScene : MonoBehaviour
{
    [SerializeField] private RoomManager roomManager;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (roomManager.IsWon && other.CompareTag("Player") )
        {
            SceneManager.LoadScene(0);
        }
    }
}

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TimerFirstScene : MonoBehaviour
{
    [SerializeField] private RoomManager roomManager;   
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timer;

    private void Update()
    {
        if (!roomManager.IsWon)
        {
            if (timer <= 0)
            {
                StartCoroutine(ResetScene());
                timer = 0f;
                timerText.text = "You loss";
            }
            else
            {
                timer -= Time.deltaTime;
                timerText.text = timer.ToString("F2");
            }
        }
        else
        {
          timerText.text = "You win!";
        }

    }
    private IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}



   


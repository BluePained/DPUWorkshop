using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TimerFirstScene : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timer;

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F2");
        }
        else
        {
            StartCoroutine(ResetScene());
            timer = 0f;
            timerText.text = "You loss";
        }

    }
    private IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}



   


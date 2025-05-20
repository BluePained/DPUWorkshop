using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUsage : MonoBehaviour
{
    public void NextScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

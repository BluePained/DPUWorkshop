using UnityEngine;
using TMPro;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField] private int fpsNumber;
    [SerializeField] private int fpsLimit;
    [SerializeField] private TMP_Text fpsText;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = fpsLimit;
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = fpsLimit;
        fpsNumber = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = fpsNumber.ToString();
    }
    public void ChangeFramerate(int index)
    {
        switch (index)
        {
            case 0:
                fpsLimit = 0;
                break;
            case 1:
                fpsLimit = 120;
                break;
            case 2:
                fpsLimit = 60;
                break;
            case 3:
                fpsLimit = 30;
                break;

        }
    }
}

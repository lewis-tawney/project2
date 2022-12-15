using UnityEngine;
using UnityEngine.UI;

public class TimerScore : MonoBehaviour
{
    public Text timerText;
    float time = 0f;
    
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = time.ToString("0.00");
    }
}


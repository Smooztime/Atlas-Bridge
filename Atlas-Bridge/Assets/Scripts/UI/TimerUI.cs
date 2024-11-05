using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject timerObject;
    [SerializeField] private TMP_Text timer;

    [SerializeField] private float timeRemaining;
    private void Start()
    {
        timerObject.SetActive(true);
    }
    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining-=Time.deltaTime;
            UpdateTimeDisplay();
        }
    }
    private void UpdateTimeDisplay()
    {
        int hours = Mathf.FloorToInt(timeRemaining / 3600);
        int minutes = Mathf.FloorToInt((timeRemaining % 3600) / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        string timeFormatted = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);

        timer.text = timeFormatted;
    }
}

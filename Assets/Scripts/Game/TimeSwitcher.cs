using UnityEngine;

public class TimeSwitcher : MonoBehaviour
{
    private int _startTimeValue = 1;
    private int _stopTimeValue = 0;

    private void Start()
    {
        Time.timeScale = _stopTimeValue;
    }

    public void StartTime() 
    {
        Time.timeScale = _startTimeValue;
    }

    public void StopTime() 
    {
        Time.timeScale = _stopTimeValue;
    }
}
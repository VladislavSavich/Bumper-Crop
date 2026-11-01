using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UICaller _uiCaller;
    [SerializeField] private TimeSwitcher _timeSwitcher;

    private void OnEnable()
    {
        _uiCaller.ButtonWasPressed += StartGame;
    }

    private void OnDisable()
    {
        _uiCaller.ButtonWasPressed -= StartGame;
    }

    public void PrepareGame()
    {
        _uiCaller.CallStartScreen();
    }

    private void OnGameOver()
    {
        _timeSwitcher.StopTime();
        _uiCaller.CallLoseScreen();
    }

    private void CompleteGame()
    {
        _timeSwitcher.StopTime();
        _uiCaller.CallVictoryScreen();
    }

    private void StartGame()
    {
        _uiCaller.CloseAllScreens();
        _timeSwitcher.StartTime();
    }
}
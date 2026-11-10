using System;
using UnityEngine;

public class UICaller : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private LevelSelectScreen _levelSelectScreen;
    [SerializeField] private EndGameScreen _loseScreen;
    //[SerializeField] private EndGameScreen _victoryScreen;

    public event Action<int> LevelWasSelected;
    public event Action LevelResetButtonClicked;
    public event Action HomeButtonClicked;
    

    private void OnEnable()
    {
        if (_startScreen == null)
            return;

        if (_levelSelectScreen == null)
            return;

        if (_loseScreen == null)
            return;

        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _levelSelectScreen.LevelSelected += OnLevelSelected;
        _loseScreen.HomeButtonClicked += CallStartScreen;
        _loseScreen.RetryButtonClicked += OnRetryButtonClicked;
    }

    private void OnDisable()
    {
        if (_startScreen == null)
            return;

        if (_levelSelectScreen == null)
            return;

        if (_loseScreen == null)
            return;

        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _levelSelectScreen.LevelSelected -= OnLevelSelected;
        _loseScreen.HomeButtonClicked -= CallStartScreen;
        _loseScreen.RetryButtonClicked -= OnRetryButtonClicked;
    }

    public void CallStartScreen()
    {
        CloseAllScreens();
        _startScreen.Open();
        HomeButtonClicked?.Invoke();
    }

    public void CallLoseScreen()
    {
        CloseAllScreens();
        _loseScreen.Open();
    }

    public void CallVictoryScreen()
    {
        CloseAllScreens();
        // _victoryScreen.Open();
    }

    public void CloseAllScreens()
    {
        _startScreen.Close();
        _levelSelectScreen.Close();
        _loseScreen.Close();
        // _victoryScreen.Close();
    }

    private void OnPlayButtonClicked()
    {
        CloseAllScreens();

        if (_levelSelectScreen != null)
            _levelSelectScreen.Open();
    }

    private void OnRetryButtonClicked()
    {
        LevelResetButtonClicked?.Invoke();
    }

    private void OnLevelSelected(int index)
    {
        CloseAllScreens();
        LevelWasSelected?.Invoke(index);
    }
}
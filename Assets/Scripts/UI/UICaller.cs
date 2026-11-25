using System;
using UnityEngine;

public class UICaller : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private LevelSelectScreen _levelSelectScreen;
    [SerializeField] private EndGameScreen _loseScreen;
    [SerializeField] private WinScreen _victoryScreen;
    [SerializeField] private GameplayScreen _gameplayScreen;
    [SerializeField] private TutorialScreen _tutorialScreen;

    public event Action<int> LevelWasSelected;
    public event Action LevelResetButtonClicked;
    public event Action StartScreenOpened;
    public event Action NextLevelButtonClicked;

    private int _tutorialLevelIndex = 0;
    
    private void OnEnable()
    {
        if (_startScreen == null)
            return;

        if (_levelSelectScreen == null)
            return;

        if (_loseScreen == null)
            return;

        if (_victoryScreen == null)
            return;

        if (_gameplayScreen == null)
            return;
        
        if(_tutorialScreen == null)
            return;

        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _levelSelectScreen.LevelSelected += OnLevelSelected;
        _loseScreen.HomeButtonClicked += CallStartScreen;
        _loseScreen.RetryButtonClicked += OnRetryButtonClicked;
        _victoryScreen.HomeButtonClicked += CallStartScreen;
        _victoryScreen.NextButtonClicked += CallNextLevel;
        _gameplayScreen.HomeButtonClicked += CallStartScreen;
    }

    private void OnDisable()
    {
        if (_startScreen == null)
            return;

        if (_levelSelectScreen == null)
            return;

        if (_loseScreen == null)
            return;

        if (_victoryScreen == null)
            return;

        if (_gameplayScreen == null)
            return;

        if(_tutorialScreen == null)
            return;
        
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _levelSelectScreen.LevelSelected -= OnLevelSelected;
        _loseScreen.HomeButtonClicked -= CallStartScreen;
        _loseScreen.RetryButtonClicked -= OnRetryButtonClicked;
        _victoryScreen.HomeButtonClicked -= CallStartScreen;
        _victoryScreen.NextButtonClicked -= CallNextLevel;
        _gameplayScreen.HomeButtonClicked -= CallStartScreen;
    }

    public void CallStartScreen()
    {
        CloseAllScreens();
        _startScreen.Open();
        StartScreenOpened?.Invoke();
    }

    public void CallLoseScreen()
    {
        CloseAllScreens();
        _loseScreen.Open();
    }

    public void CallVictoryScreen()
    {
        CloseAllScreens();
        _victoryScreen.Open();
    }

    public void CallGameplayScreen()
    {
        _gameplayScreen.Open();
    }

    public void UpdateWinScore(int value, int targetValue)
    {
        _gameplayScreen.UpdateView(value, targetValue);
    }

    public void CloseAllScreens()
    {
        _startScreen.Close();
        _levelSelectScreen.Close();
        _loseScreen.Close();
        _victoryScreen.Close();
        _gameplayScreen.Close();
        _tutorialScreen.Close();
    }

    private void CallNextLevel()
    {
        CloseAllScreens();
        NextLevelButtonClicked?.Invoke();
    }

    private void OnPlayButtonClicked()
    {
        CloseAllScreens();

        if (_levelSelectScreen != null)
            _levelSelectScreen.Open();
    }

    private void OnRetryButtonClicked()
    {
        CloseAllScreens();
        LevelResetButtonClicked?.Invoke();
    }

    private void OnLevelSelected(int index)
    {
        CloseAllScreens();
        LevelWasSelected?.Invoke(index);
        
        if(index == _tutorialLevelIndex)
            _tutorialScreen.Open();

        CallGameplayScreen();
    }
}
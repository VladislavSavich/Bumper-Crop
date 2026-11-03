using System;
using UnityEngine;

public class UICaller : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private LevelSelectScreen _levelSelectScreen;
    //[SerializeField] private EndGameScreen _loseScreen;
    //[SerializeField] private EndGameScreen _victoryScreen;
   
    public event Action<int> LevelWasSelected;

    private void OnEnable()
    {
        if (_startScreen != null)
            _startScreen.PlayButtonClicked += OnPlayButtonClicked;

        if (_levelSelectScreen != null)
            _levelSelectScreen.LevelSelected += OnLevelSelected;
    }

    private void OnDisable()
    {
        if (_startScreen != null)
            _startScreen.PlayButtonClicked -= OnPlayButtonClicked;

        if (_levelSelectScreen != null)
            _levelSelectScreen.LevelSelected -= OnLevelSelected;
    }

    public void CallStartScreen()
    {
        _startScreen.Open();
        CloseLevelSelect();
    }

    public void CallLoseScreen()
    {
       // _loseScreen.Open();
    }

    public void CallVictoryScreen()
    {
       // _victoryScreen.Open();
    }

    public void CloseAllScreens()
    {
        _startScreen.Close();
        CloseLevelSelect();
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();

        if (_levelSelectScreen != null)
            _levelSelectScreen.Open();
    }

    private void OnLevelSelected(int index)
    {
        CloseLevelSelect();
        LevelWasSelected?.Invoke(index);
    }

    private void CloseLevelSelect()
    {
        if (_levelSelectScreen != null)
            _levelSelectScreen.Close();
    }
}
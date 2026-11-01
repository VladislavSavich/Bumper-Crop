using System;
using UnityEngine;

public class UICaller : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _loseScreen;
    [SerializeField] private EndGameScreen _victoryScreen;

    public event Action ButtonWasPressed;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnButtonClick;
        /*_loseScreen.RestartButtonClicked += OnButtonClick;
        _victoryScreen.RestartButtonClicked += OnButtonClick;*/
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnButtonClick;
        /*_loseScreen.RestartButtonClicked -= OnButtonClick;
        _victoryScreen.RestartButtonClicked -= OnButtonClick;*/
    }

    public void CallStartScreen() 
    {
        _startScreen.Open(); 
    }

    public void CallLoseScreen() 
    {
        _loseScreen.Open();
    }

    public void CallVictoryScreen() 
    {
        _victoryScreen.Open();
    }

    public void CloseAllScreens() 
    {
        _startScreen.Close();
        /*_loseScreen.Close();
        _victoryScreen.Close();*/
    }

    private void OnButtonClick()
    {
        CloseAllScreens();
        ButtonWasPressed?.Invoke();
    }
}
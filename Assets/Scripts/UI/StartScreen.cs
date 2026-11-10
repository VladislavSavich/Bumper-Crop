using System;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : Window
{
    [SerializeField] private Button _startButton;
    //[SerializeField]  private Button _shopButton;
    
    public event Action PlayButtonClicked;

    private void OnEnable()
    {
        if (_startButton != null)
            _startButton.onClick.AddListener(PlayButtonClick);
    }
    
    private void OnDisable()
    {
        if (_startButton != null)
            _startButton.onClick.RemoveListener(PlayButtonClick);
    }

    private void PlayButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
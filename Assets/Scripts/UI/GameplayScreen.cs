using System;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : Window
{
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _soundButton;

    public event Action HomeButtonClicked;
    public event Action SoundButtonClicked;

    private void Start()
    {
        Close();
    }
    
    private void OnEnable()
    {
        if (_homeButton != null)
            _homeButton.onClick.AddListener(HomeButtonClick);
    }

    private void OnDisable()
    {
        if (_homeButton != null)
            _homeButton.onClick.RemoveListener(HomeButtonClick);
    }
    
    private void HomeButtonClick()
    {
        HomeButtonClicked?.Invoke();
    }

    private void SoundButtonClick()
    {
        SoundButtonClicked?.Invoke();
    }
}

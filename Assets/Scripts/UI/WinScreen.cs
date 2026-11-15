using System;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : Window
{
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _nextLevelButton;

    public event Action HomeButtonClicked;
    public event Action NextButtonClicked;

    private void Start()
    {
        Close();
    }

    private void OnEnable()
    {
        if (_homeButton != null)
            _homeButton.onClick.AddListener(HomeButtonClick);

        if (_nextLevelButton != null)
            _nextLevelButton.onClick.AddListener(NextButtonClick);
    }

    private void OnDisable()
    {
        if (_homeButton != null)
            _homeButton.onClick.RemoveListener(HomeButtonClick);

        if (_nextLevelButton != null)
            _nextLevelButton.onClick.RemoveListener(NextButtonClick);
    }

    private void HomeButtonClick()
    {
        HomeButtonClicked?.Invoke();
    }

    private void NextButtonClick()
    {
        NextButtonClicked?.Invoke();
    }
}
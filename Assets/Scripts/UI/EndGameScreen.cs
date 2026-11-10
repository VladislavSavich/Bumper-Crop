using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : Window
{
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _retryButton;
    //[SerializeField] private Button _adButton;

    public event Action HomeButtonClicked;
    public event Action RetryButtonClicked;

    private void Start()
    {
        Close();
    }

    private void OnEnable()
    {
        if (_homeButton != null)
            _homeButton.onClick.AddListener(HomeButtonClick);

        if (_retryButton != null)
            _retryButton.onClick.AddListener(RetryButtonClick);
    }

    private void OnDisable()
    {
        if (_homeButton != null)
            _homeButton.onClick.RemoveListener(HomeButtonClick);

        if (_retryButton != null)
            _retryButton.onClick.RemoveListener(RetryButtonClick);
    }

    private void HomeButtonClick()
    {
        HomeButtonClicked?.Invoke();
    }

    private void RetryButtonClick()
    {
        RetryButtonClicked?.Invoke();
    }
}
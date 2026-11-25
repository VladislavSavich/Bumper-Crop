using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayScreen : Window
{
    [SerializeField] private Button _homeButton;
    [SerializeField] private HarvestCounter _counter;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    public event Action HomeButtonClicked;

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

    public void UpdateView(int value, int targetValue)
    {
        _scoreText.text = $"{value} / {targetValue}";
    }

    private void HomeButtonClick()
    {
        HomeButtonClicked?.Invoke();
    }
}

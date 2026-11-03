using System;
using UnityEngine;

public class LevelSelectScreen : Window
{
    [SerializeField] private LevelButton[] _levelButtons;

    public event Action<int> LevelSelected;

    private void Awake()
    {
        foreach (var button in _levelButtons)
        {
            if (button != null)
            {
                button.Clicked += OnLevelButtonClicked;
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var button in _levelButtons)
        {
            if (button != null)
            {
                button.Clicked -= OnLevelButtonClicked;
            }
        }
    }

    private void OnLevelButtonClicked(int levelIndex)
    {
        LevelSelected?.Invoke(levelIndex);
    }
}
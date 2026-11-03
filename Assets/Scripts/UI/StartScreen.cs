using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    private void Awake()
    {
        if (_actionButton != null)
            _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDestroy()
    {
        if (_actionButton != null)
            _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
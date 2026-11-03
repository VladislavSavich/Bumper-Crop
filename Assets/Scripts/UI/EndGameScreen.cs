using System;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {
        _windowGroup.alpha = 0f;
        _actionButton.interactable = false;
        _windowGroup.blocksRaycasts = false;
    }

    public override void Open()
    {
        _windowGroup.alpha = 1f;
        _actionButton.interactable = true;
        _windowGroup.blocksRaycasts = true;
    }

    private void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
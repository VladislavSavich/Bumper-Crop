using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _windowGroup;
    [SerializeField] protected Button _actionButton;

    public virtual void Close()
    {
        if (_windowGroup != null)
        {
            _windowGroup.alpha = 0f;
            _windowGroup.interactable = false;
            _windowGroup.blocksRaycasts = false;
        }

        gameObject.SetActive(false);
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);

        if (_windowGroup != null)
        {
            _windowGroup.alpha = 1f;
            _windowGroup.blocksRaycasts = true;
            _windowGroup.interactable = true;
        }

        if (_actionButton != null)
        {
            _actionButton.interactable = true;
        }
    }
}
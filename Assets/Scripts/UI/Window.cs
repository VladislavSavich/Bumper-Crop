using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _windowGroup;
    
    public void Close()
    {
        if (_windowGroup != null)
        {
            _windowGroup.alpha = 0f;
            _windowGroup.interactable = false;
            _windowGroup.blocksRaycasts = false;
        }

        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);

        if (_windowGroup == null) 
            return;
        
        _windowGroup.alpha = 1f;
        _windowGroup.blocksRaycasts = true;
        _windowGroup.interactable = true;
    }
}
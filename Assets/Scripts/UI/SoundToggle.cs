using UnityEngine.UI;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private bool _isSoundOn = true;

    public void ToggleSound()
    {
        _isSoundOn = !_isSoundOn;

        AudioListener.volume = _isSoundOn ? 1.0f : 0.0f;

        UpdateSoundState();
    }

    private void UpdateSoundState()
    {
        _buttonImage.sprite = _isSoundOn ? _soundOn : _soundOff;
    }
}
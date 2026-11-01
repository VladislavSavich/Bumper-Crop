using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _cutClip;
    [SerializeField] private AudioClip _bonusClip;

    private float _minValue = 0.9f;
    private float _midValue = 1f;
    private float _maxValue = 1.1f;
    
    public void PlaySound(Grass grass)
    {
        _audioSource.pitch =  Random.Range(_minValue, _maxValue);
        _audioSource.PlayOneShot(_cutClip);
    }
    
    public void PlaySound(Bonus bonus)
    {
        _audioSource.pitch = _midValue;
        _audioSource.PlayOneShot(_bonusClip);
    }
}

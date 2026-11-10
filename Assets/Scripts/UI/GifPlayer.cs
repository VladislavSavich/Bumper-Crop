using GifImporter;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SimpleGifPlayer : MonoBehaviour
{
    [SerializeField] private Gif _gif;
        
    private SpriteRenderer _spriteRenderer;
    
    private int _frameIndex;
    private float _nextFrameTime;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        ResetAnimation();
    }

    private void Update()
    {
        if (!_gif || _gif.Frames == null || _gif.Frames.Count == 0)
            return;
            
        if (Time.unscaledTime >= _nextFrameTime)
            AdvanceFrame();
    }

    private void AdvanceFrame()
    {
        var frames = _gif.Frames;
        _frameIndex++;
            
        if (_frameIndex >= frames.Count)
            _frameIndex = 0;

        ApplyCurrentFrame(frames[_frameIndex]);
    }

    private void ApplyCurrentFrame(GifFrame frame)
    {
        _nextFrameTime = Time.unscaledTime + (frame.DelayInMs * 0.001f);
            
        if (_spriteRenderer)
            _spriteRenderer.sprite = frame.Sprite;

    }

    private void ResetAnimation()
    {
        _frameIndex = 0;
            
        if (_gif != null && _gif.Frames != null && _gif.Frames.Count > 0)
            ApplyCurrentFrame(_gif.Frames[0]);
    }
}
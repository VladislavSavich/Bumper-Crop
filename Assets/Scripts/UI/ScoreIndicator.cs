using TMPro;
using UnityEngine;

public class ScoreIndicator : MonoBehaviour
{
    [SerializeField] private HarvestCounter _counter;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _minScore = 0;

    private void Start()
    {
        _scoreText.text = _minScore.ToString();
    }

    private void OnEnable()
    {
        _counter.CountChanged += UpdateView;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= UpdateView;
    }

    private void UpdateView(int value)
    {
        _scoreText.text = value.ToString();
    }
}
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private Transform _levelRoot;

    private GameObject _currentLevel;

    private void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        UnloadLevel();

        if (_levelPrefab == null)
            return;

        if (_levelRoot == null)
            _levelRoot = transform;

        _currentLevel = Instantiate(_levelPrefab, _levelRoot);
    }

    public void UnloadLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _currentLevel = null;
        }
    }
}

using System;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelPrefabs;
    [SerializeField] private Transform _levelRoot;

    private GameObject _currentLevel;
    private int _currentLevelIndex;
    
    public void LoadLevel(int index)
    {
        UnloadLevel();

        if (_levelPrefabs == null || index < 0 || index >= _levelPrefabs.Length)
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс {index} вне диапазона для массива уровней");

        if (_levelRoot == null)
            _levelRoot = transform;

        _currentLevel = Instantiate(_levelPrefabs[index]);
        _currentLevelIndex = index;
    }

    public void ReloadLevel()
    {
        UnloadLevel();
        LoadLevel(_currentLevelIndex);
    }

    public void UnloadLevel()
    {
        if (_currentLevel == null) 
            return;
        
        Destroy(_currentLevel);
        _currentLevel = null;
    }
}
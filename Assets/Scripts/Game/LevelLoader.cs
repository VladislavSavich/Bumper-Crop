using System;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelPrefabs;
    [SerializeField] private Transform _levelRoot;
    [SerializeField] private GrassSpawner _grassSpawner;
    [SerializeField] private BonusSpawner _bonusSpawner;

    private GameObject _currentLevel;
    
    public int CurrentLevelIndex { get; private set; }

    public void LoadLevel(int index)
    {
        if (_levelPrefabs == null || index < 0 || index >= _levelPrefabs.Length)
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс {index} вне диапазона для массива уровней");

        if (_levelRoot == null)
            _levelRoot = transform;

        _currentLevel = Instantiate(_levelPrefabs[index]);
        _grassSpawner.SpawnGrassField();
        _bonusSpawner.SpawnDelay();
        CurrentLevelIndex = index;
    }
    
    public bool TryLoadNextLevel()
    {
        CurrentLevelIndex++;
        
        return CurrentLevelIndex < _levelPrefabs.Length;
    }

    public void ReloadLevel()
    {
        UnloadLevel();
        LoadLevel(CurrentLevelIndex);
    }

    public void UnloadLevel()
    {
        if (_currentLevel == null) 
            return;
        
        _grassSpawner.ClearAllGrass();
        _bonusSpawner.ClearAllBonus();
        _currentLevel.SetActive(false);
        Destroy(_currentLevel);
        _currentLevel = null;
    }
}
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UICaller _uiCaller;
    [SerializeField] private GrassSpawner  _grassSpawner;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private TimeSwitcher _timeSwitcher;

    private void OnEnable()
    {
        _uiCaller.LevelWasSelected += StartGame;
        _uiCaller.LevelWasSelected += _grassSpawner.SpawnGrassField;
    }

    private void OnDisable()
    {
        _uiCaller.LevelWasSelected -= StartGame;
        _uiCaller.LevelWasSelected -= _grassSpawner.SpawnGrassField;
    }

    private void OnGameOver()
    {
        _timeSwitcher.StopTime();
        _uiCaller.CallLoseScreen();
    }

    private void CompleteLevel()
    {
        _timeSwitcher.StopTime();
        _uiCaller.CallVictoryScreen();
    }

    private void StartGame(int levelIndex)
    {
        _uiCaller.CloseAllScreens();
        _levelLoader.LoadLevel(levelIndex);
        _timeSwitcher.StartTime();
    }
}